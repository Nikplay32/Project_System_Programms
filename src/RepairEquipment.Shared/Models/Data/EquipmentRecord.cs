using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.Equipment)]
    public sealed record EquipmentRecord
    {
        [Column(Equipment.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }

        [Column(Equipment.Brand, CanBeNull = false)]
        public string Brand { get; set; } = string.Empty;

        [Column(Equipment.Model, CanBeNull = false)]      
        public string Model { get; set; } = string.Empty;

        [Column(Equipment.TypeId, CanBeNull = false)]
        public int TypeID { get; set; }

        [Column(Equipment.SerialNumber, CanBeNull = true)]
        public string SerialNumber { get; set; } = string.Empty;

        [Column(Equipment.PurchaseDate, CanBeNull = false)]
        public DateTime? PurchaseDate { get; set; }      
        
        [Column(Equipment.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}