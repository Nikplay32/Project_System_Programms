using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.EquipmentHistory)]
    public sealed record EquipmentHistoryRecord
    {
        [Column(EquipmentHistory.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }
         
        [Column(EquipmentHistory.Brand, CanBeNull = false)]
        public string Brand { get; set; } = string.Empty;

        [Column(EquipmentHistory.Model, CanBeNull = false)]
        public string Model { get; set; } = string.Empty;

        [Column(EquipmentHistory.EquipmentType, CanBeNull = false)]
        public string EquipmentType { get; set; } = string.Empty;

        [Column(EquipmentHistory.Client, CanBeNull = false)]
        public string Client { get; set; } = string.Empty;

        [Column(EquipmentHistory.Employee, CanBeNull = false)]
        public string Employee { get; set; } = string.Empty;

        [Column(EquipmentHistory.DocumentNumber, CanBeNull = false)]
        public string DocumentNumber { get; set; } = string.Empty;

        [Column(EquipmentHistory.DocumentDateOut, CanBeNull = false)]
        public DateTime? DocumentDateOut { get; set; }

        [Column(EquipmentHistory.DocumentDateIn)]
        public DateTime? DocumentDateIn { get; set; }

        [Column(EquipmentHistory.Quantity, CanBeNull = false)]
        public decimal Quantity { get; set; }
        public DateTime Created { get; init; }
        
    }
}