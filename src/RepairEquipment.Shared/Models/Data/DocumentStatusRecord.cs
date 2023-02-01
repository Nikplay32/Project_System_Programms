using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.DocumentStatus)]
    public sealed record DocumentStatusRecord
    {
        [Column(DocumentStatus.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        [Column(DocumentStatus.Name, CanBeNull = false)]
        public string Name { get; set; } = string.Empty;

        [Column(DocumentStatus.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}
