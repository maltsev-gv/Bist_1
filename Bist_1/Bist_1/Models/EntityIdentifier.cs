using Bist_1.Interfaces;

namespace Bist_1.Models
{
    public class EntityIdentifier : IEntityIdentifier
    {
        public string EntityType { get; set; }
        public int EntityId { get; set; }
    }
}
