using System;
using System.Collections.Generic;
using System.Linq;

namespace Intersect.Server.Entities.Factions;

/// <summary>
/// Registry of factions and active wars. Entity.ResolveFactionAlly calls
/// AreAtWar on every hostility check, so keep that method cheap (in-memory
/// list scan, no DB hit) — the TODOs below are where you wire up actual
/// persistence, loaded once at server start into these in-memory
/// collections.
/// </summary>
public static class FactionManager
{
    private static readonly Dictionary<Guid, Faction> Factions = new();
    private static readonly List<FactionWar> ActiveWars = new();

    public static void Register(Faction faction) => Factions[faction.Id] = faction;

    public static Faction? Get(Guid factionId) =>
        Factions.TryGetValue(factionId, out var f) ? f : null;

    public static bool AreAtWar(Guid factionA, Guid factionB) =>
        ActiveWars.Any(w => w.IsBetween(factionA, factionB));

    /// <summary>
    /// Declares war on behalf of a faction leader. Enforces leadership,
    /// per-faction cooldown, and blocks duplicate wars. On Success, the
    /// caller (see DeclareWarEventCommand) is responsible for refreshing
    /// affected maps' NPCs — kept separate so this class has no dependency
    /// on map/instance code.
    /// </summary>
    public static DeclareWarResult DeclareWar(Guid invokingPlayerId, Guid declaringFactionId, Guid targetFactionId)
    {
        if (!Factions.TryGetValue(declaringFactionId, out var declaring) ||
            !Factions.ContainsKey(targetFactionId))
        {
            return DeclareWarResult.UnknownFaction;
        }

        if (declaring.LeaderPlayerId != invokingPlayerId)
        {
            return DeclareWarResult.NotLeader;
        }

        if (declaring.LastWarDeclarationTime.HasValue &&
            DateTime.UtcNow - declaring.LastWarDeclarationTime.Value < Faction.WarDeclarationCooldown)
        {
            return DeclareWarResult.OnCooldown;
        }

        if (AreAtWar(declaringFactionId, targetFactionId))
        {
            return DeclareWarResult.AlreadyAtWar;
        }

        ActiveWars.Add(new FactionWar { FactionAId = declaringFactionId, FactionBId = targetFactionId });
        declaring.LastWarDeclarationTime = DateTime.UtcNow;

        // TODO: persist the new FactionWar row and declaring.LastWarDeclarationTime
        // to your DbContext here.

        return DeclareWarResult.Success;
    }

    public static bool EndWar(Guid factionA, Guid factionB)
    {
        var removed = ActiveWars.RemoveAll(w => w.IsBetween(factionA, factionB));
        // TODO: persist removal.
        return removed > 0;
    }
}
