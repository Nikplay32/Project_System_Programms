using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class DocumentStatusService : IDocumentStatusService
    {
        private readonly SqlDataAccess _conn;
        public DocumentStatusService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task<List<DocumentStatusRecord>> GetDocumentStatusListAsync() =>
            await _conn
                .DocumentStatusRecords
                .ToListAsync();

    }
}
