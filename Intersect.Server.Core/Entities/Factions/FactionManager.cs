using System;
using Intersect.Framework.Core.GameObjects.Factions;
using Intersect.Server.Database;

namespace Intersect.Server.Entities.Factions;

public enum DeclareWarResult
{
    Success,
    NotLeader,
    OnCooldown,
    AlreadyAtWar,
    UnknownFaction
}

/// <summary>
/// War-declaration logic on top of FactionDescriptor, which is now the real,
/// persisted, Editor-manageable game object (see GameObjectType.Faction).
/// Entity.ResolveFactionAlly calls FactionDescriptor.IsAtWarWith directly for
/// the hostility check itself — this class is only for the leader-facing
/// DeclareWar action and its cooldown/permission rules.
/// </summary>
public static class FactionManager
{
    /// <summary>
    /// Declares war on behalf of a faction leader. Enforces leadership,
    /// per-faction cooldown, and blocks duplicate wars. Updates both
    /// factions' AtWarWith lists (symmetric) and saves them. On Success, the
    /// caller (see DeclareWarEventCommand) is responsible for refreshing
    /// affected maps' NPCs — kept separate so this class has no dependency
    /// on map/instance code.
    /// </summary>
    public static DeclareWarResult DeclareWar(Guid invokingPlayerId, Guid declaringFactionId, Guid targetFactionId)
    {
        var declaring = FactionDescriptor.Get(declaringFactionId);
        var target = FactionDescriptor.Get(targetFactionId);

        if (declaring == null || target == null)
        {
            return DeclareWarResult.UnknownFaction;
        }

        if (declaring.LeaderPlayerId != invokingPlayerId)
        {
            return DeclareWarResult.NotLeader;
        }

        if (declaring.LastWarDeclarationTime.HasValue &&
            DateTime.UtcNow - declaring.LastWarDeclarationTime.Value < TimeSpan.FromHours(declaring.WarCooldownHours))
        {
            return DeclareWarResult.OnCooldown;
        }

        if (declaring.IsAtWarWith(targetFactionId))
        {
            return DeclareWarResult.AlreadyAtWar;
        }

        declaring.AtWarWith.Add(targetFactionId);
        target.AtWarWith.Add(declaringFactionId);
        declaring.LastWarDeclarationTime = DateTime.UtcNow;

        DbInterface.SaveGameObject(declaring);
        DbInterface.SaveGameObject(target);

        return DeclareWarResult.Success;
    }

    public static bool EndWar(Guid factionA, Guid factionB)
    {
        var a = FactionDescriptor.Get(factionA);
        var b = FactionDescriptor.Get(factionB);

        if (a == null || b == null)
        {
            return false;
        }

        var removed = a.AtWarWith.Remove(factionB);
        b.AtWarWith.Remove(factionA);

        if (removed)
        {
            DbInterface.SaveGameObject(a);
            DbInterface.SaveGameObject(b);
        }

        return removed;
    }

    public static bool AreAtWar(Guid factionA, Guid factionB) =>
        FactionDescriptor.Get(factionA)?.IsAtWarWith(factionB) ?? false;
}
