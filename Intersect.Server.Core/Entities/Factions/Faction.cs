using System;
using System.Collections.Generic;

namespace Intersect.Server.Entities.Factions;

public class Faction
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// PlayerId of the current leader. Only this player may DeclareWar on
    /// this faction's behalf (checked in FactionManager.DeclareWar).
    /// </summary>
    public Guid? LeaderPlayerId { get; set; }

    public DateTime? LastWarDeclarationTime { get; set; }

    public static readonly TimeSpan WarDeclarationCooldown = TimeSpan.FromHours(1);
}

/// <summary>
/// A single active war between two factions — symmetric, no attacker/defender
/// distinction. Existence of a row (either direction) is what
/// Entity.ResolveFactionAlly checks via FactionManager.AreAtWar.
/// </summary>
public class FactionWar
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid FactionAId { get; set; }

    public Guid FactionBId { get; set; }

    public DateTime DeclaredAt { get; set; } = DateTime.UtcNow;

    public bool IsBetween(Guid factionA, Guid factionB) =>
        (FactionAId == factionA && FactionBId == factionB) ||
        (FactionAId == factionB && FactionBId == factionA);
}

public enum DeclareWarResult
{
    Success,
    NotLeader,
    OnCooldown,
    AlreadyAtWar,
    UnknownFaction
}
