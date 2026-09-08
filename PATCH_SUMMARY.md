# Patch Summary — Faction/Race/Damage-Typing/Party Changes

This zip is your uploaded Intersect-Engine source with the following changes
already applied and building on the exact code paths we traced through
together. Everything below is a real edit to a real file — nothing here is
a generic sketch.

## 1. Damage Typing (Element system)

- **New:** `Intersect (Core)/Enums/Element.cs` — `None, Fire, Frost, Storm,
  Nature, Holy, Shadow`, mirroring the existing `DamageType` enum exactly.
- **`ItemDescriptor.cs`**: added `Element` field (parallel to `DamageType`),
  plus `ElementalResistance`/`PercentageElementalResistance` int arrays,
  mirroring the existing `StatsGiven`/`PercentageStatsGiven` DB-column pattern
  precisely (same `DatabaseUtils.SaveIntArray`/`LoadIntArray` convention, same
  `[NotMapped]`/`[Column]` attributes). Both arrays are initialized alongside
  `StatsGiven` in the constructor.
- **`SpellCombatDescriptor.cs`**: added `Element` field next to `DamageType`.
- **`NPCDescriptor.cs`**: added `Element` field plus the same two resistance
  arrays. **Check this one**: unlike `ItemDescriptor`, `NPCDescriptor`'s
  existing `Stats` array uses a custom backing field (`_stats`) rather than
  the `DatabaseUtils`/`[Column]` pattern — I added the new arrays as plain
  `[NotMapped]` properties, but you should confirm they actually persist the
  same way `Stats` does (there may be a JSON-blob-for-the-whole-object
  mechanism elsewhere that `[NotMapped]` here doesn't hook into). If NPC
  resistances aren't surviving a server restart, this is where to look.
- **`Formulas.CalculateDamage`** (`Intersect.Server.Core/General/Formulas.cs`):
  added an `Element element = Element.None` parameter. After the existing
  Physical/Magic/True formula evaluates, flat-then-percent elemental
  resistance is applied on top — skipped entirely for `True` damage and for
  negative baseDamage (healing), so healing formulas are unaffected.
- **`Entity.GetElementalResistance(Element)`** (virtual, in `Entity.cs`):
  new method — `Npc` reads its descriptor directly; `Player` sums across
  every equipped item's resistance arrays (so Race/Backstory gear
  contributes automatically, no special-casing needed).
- **Editor UI**: `frmItem.cs`, `frmSpell.cs`, `frmNpc.cs` all now populate,
  load, and save a `cmbElement` combo the same way `cmbDamageType` already
  works — reads/writes `mEditorItem.Element` (or `mEditorItem.Combat.Element`
  for spells). Matching `Strings.Combat.elementtypes` localization dictionary
  and an `elementtype` label string were added to
  `Intersect.Editor/Localization/Strings.cs` for all four editors
  (Class/Item/Npc/Spell).
- **NOT DONE — needs Visual Studio**: the actual visible `cmbElement`/
  `lblElement` controls in each form's `.Designer.cs` file. These editors use
  fixed pixel coordinates (e.g. `cmbDamageType.Location = new Point(18,
  175)`), and the next control down (`cmbScalingStat` etc.) sits only ~4px
  below — there's no room to insert a new row without shifting every
  subsequent control down by ~24-40px. That's a cascade I can't verify blind
  against thousands of lines of coordinates. **Open each form in the Visual
  Studio designer, drag a new ComboBox + Label into the group box, name them
  `cmbElement`/`lblElement`, and wire `SelectedIndexChanged` to the handler
  already written in the `.cs` file** (`cmbElement_SelectedIndexChanged`
  already exists in all three — the designer just needs to hook the event).

## 2. Faction System

- **`Entity.cs`**: added `FactionId` (nullable Guid) and
  `ResolveFactionAlly(Entity)` — returns `true` for same faction, `false` for
  an active war (hard override), or `null` ("no opinion, use your existing
  rules"). This is a pure addition — any entity with `FactionId == null`
  behaves exactly as before.
- **`Player.IsAllyOf(Player)`** and **`Npc.IsAllyOf(Entity)`**: both now call
  `ResolveFactionAlly` first and only fall through to the existing
  party/guild/`PlayerFriendConditions` logic when it returns `null`.
- **New:** `Intersect.Server.Core/Entities/Factions/Faction.cs` (`Faction`,
  `FactionWar`, `DeclareWarResult`) and `FactionManager.cs` (in-memory
  registry, `AreAtWar`, `DeclareWar` with leader + cooldown checks).
- **NOT DONE**: persistence (the two `// TODO` comments in
  `FactionManager.DeclareWar`/`EndWar`) — wire those to your DbContext when
  you add `DbSet<Faction>`/`DbSet<FactionWar>`. Also not done: the
  `DeclareWarEventCommand` registration into your event-command
  enum/switch, the map-NPC-refresh trigger on war declaration, territory
  ownership via Global Variables, and `PlayerFactionReputation` — all
  designed in our conversation but not yet matched against real files in
  this repo (send me your event-command switch file and I'll finish this
  the same way).

## 3. Race/Backstory equipment slots

- **`EquipmentOptions.cs`**: added `"Race"` and `"Backstory"` to the default
  `Slots` list, plus a new `LockedSlots` list (`["Race", "Backstory"]`).
- **`Player.cs`**: new `IsSlotLocked(int)` (checks `LockedSlots` config +
  whether something's already equipped there) and `SetLockedSlotItem(...)`
  (bypasses the lock for intentional changes — call this from a race-change
  potion's script/event, not from normal inventory equip). `EquipItem` and
  both `UnequipItem` overloads now check `IsSlotLocked` before proceeding.

## 4. Party size

- **`PartyOptions.cs`**: `MaximumMembers` default changed `4` → `5`.
  `PartyWindow.cs` already loops off this value for all its C# control
  creation — confirmed no other code change needed there.
- **NOT DONE**: the actual pixel layout for the party HUD lives in a JSON UI
  resource file that ships separately from this source repo (not present
  here). You'll need to add entries for member index 4 following the exact
  naming convention `PartyWindow.cs` already uses: `MemberName4`,
  `HealthBarContainer4`, `HealthLabel4`, `HealthValue4`, `ManaBarContainer4`,
  `ManaLabel4`, `ManaValue4`, `KickButton4` — plus resize the window itself
  to fit a 5th row.

## What to send next

- Your event-command enum/switch file → I'll finish Declare War, territory
  ownership, and reputation.
- Confirmation of how `NPCDescriptor` actually persists non-`Stats`-pattern
  arrays, if the elemental resistance fields aren't surviving a restart.
- Nothing needed from you for the Designer.cs UI — that one's manual by
  necessity, but the event handlers are already written and waiting.
