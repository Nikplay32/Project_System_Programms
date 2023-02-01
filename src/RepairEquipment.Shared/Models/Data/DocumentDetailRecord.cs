using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.DocumentDetail)]
    public sealed record DocumentDetailRecord
    {
        [Column(DocumentDetail.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; set; }

        [Column(DocumentDetail.DocumentId)]
        public int DocumentID { get; set; }

        [Column(DocumentDetail.DocumentDateOut)]
        public DateTime? DocumentDateOut { get; set; }

        [Column(DocumentDetail.DocumentDateIn)]
        public DateTime? DocumentDateIn { get; set; }

        [Column(DocumentDetail.Quantity)]
        public decimal Quantity { get; set; }

        [Column(DocumentDetail.EquipmentId)]
        public int EquipmentID { get; set; }

        [Column(DocumentDetail.StatusId)]
        public int StatusID { get; set; }

        [Column(DocumentDetail.IssueDescription)]
        public string IssueDescription { get; set; } = string.Empty;

        [Column(DocumentDetail.Created, CanBeNull = false)]
        public DateTime Created { get; init; }
    }
}