using System.ComponentModel.DataAnnotations.Schema;
using Intersect.Models;
using Newtonsoft.Json;

namespace Intersect.Framework.Core.GameObjects.Factions;

/// <summary>
/// A named faction that Players and Npcs can belong to (via their FactionId).
/// Editable through the Editor the same way Items/NPCs/Spells are.
/// </summary>
public partial class FactionDescriptor : DatabaseObject<FactionDescriptor>, IFolderable
{
    /// <summary>
    /// PlayerId of the current leader. Only this player may declare war on
    /// this faction's behalf. Null = no leader; no one can declare war.
    /// </summary>
    public Guid? LeaderPlayerId { get; set; }

    /// <summary>
    /// How many hours must pass between this faction's war declarations.
    /// </summary>
    public int WarCooldownHours { get; set; } = 1;

    public DateTime? LastWarDeclarationTime { get; set; }

    /// <summary>
    /// Other factions this one is currently at war with. Symmetric — both
    /// sides' lists are updated together when war is declared or ended, so
    /// either side's list alone is authoritative for hostility checks.
    /// </summary>
    [NotMapped]
    public DbList<FactionDescriptor> AtWarWith { get; set; } = [];

    [JsonIgnore]
    [Column("AtWarWith")]
    public string AtWarWithJson
    {
        get => JsonConvert.SerializeObject(AtWarWith, Formatting.None);
        protected set => AtWarWith = JsonConvert.DeserializeObject<DbList<FactionDescriptor>>(value) ?? [];
    }

    [JsonConstructor]
    public FactionDescriptor(Guid id) : base(id)
    {
        Name = "New Faction";
    }

    //Parameterless constructor for EF
    public FactionDescriptor()
    {
        Name = "New Faction";
    }

    /// <inheritdoc />
    public string Folder { get; set; } = string.Empty;

    public bool IsAtWarWith(Guid otherFactionId) => AtWarWith.Contains(otherFactionId);
}
