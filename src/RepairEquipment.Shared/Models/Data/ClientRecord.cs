using LinqToDB.Mapping;
using RepairEquipment.Data;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Shared.Models.Data
{
    [Table(Tables.Client)]
    public sealed record ClientRecord
    {
        [Column(Client.Id, IsPrimaryKey = true, IsIdentity = true)]
        public int ID { get; init; }

        [Column(Client.Name, CanBeNull = false)]
        public string Name { get; set; } = string.Empty;

        [Column(Client.RegistrationNr, CanBeNull = false)]
        public string RegistrationNr { get; set; } = string.Empty;

        [Column(Client.LegalAddress, CanBeNull = false)]
        public string LegalAddress { get; set; } = string.Empty;

        [Column(Client.Phone, CanBeNull = false)]
        public string Phone { get; set; } = string.Empty;

        [Column(Client.Email, CanBeNull = false)]
        public string Email { get; set; } = string.Empty;
        public DateTime Created { get; init; }
    }
}