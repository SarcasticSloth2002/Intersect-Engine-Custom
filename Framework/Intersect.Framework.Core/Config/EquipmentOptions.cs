using System.Runtime.Serialization;

namespace Intersect.Config;

public partial class EquipmentOptions
{
    public PaperdollOptions Paperdoll { get; set; } = new();

    public int ShieldSlot { get; set; } = 3;

    public List<string> Slots { get; set; } =
    [
        "Helmet",
        "Armor",
        "Weapon",
        "Shield",
        "Boots",
        "Race",
        "Backstory",
    ];

    /// <summary>
    /// Slot names that, once something is equipped there, cannot be
    /// unequipped or swapped through normal means (Player.EquipItem/
    /// UnequipItem both check this). Use Player.SetLockedSlotItem to bypass
    /// intentionally (a race-change potion, a quest reward, etc).
    /// </summary>
    public List<string> LockedSlots { get; set; } =
    [
        "Race",
        "Backstory",
    ];

    public List<string> ToolTypes { get; set; } =
    [
        "Axe",
        "Pickaxe",
        "Shovel",
        "Fishing Rod",
    ];

    public int WeaponSlot = 2;

    [OnDeserializing]
    internal void OnDeserializingMethod(StreamingContext context)
    {
        Slots.Clear();
        ToolTypes.Clear();
    }

    [OnDeserialized]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        Validate();
    }

    public void Validate()
    {
        Slots = [..Slots.Distinct()];
        ToolTypes = [..ToolTypes.Distinct()];
        if (WeaponSlot < -1 || WeaponSlot > Slots.Count - 1)
        {
            throw new Exception("Config Error: (WeaponSlot) was out of bounds!");
        }

        if (ShieldSlot < -1 || ShieldSlot > Slots.Count - 1)
        {
            throw new Exception("Config Error: (ShieldSlot) was out of bounds!");
        }

        Paperdoll.Validate(this);
    }
}
