using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services
{
    public sealed class DocumentDetailsService : IDocumentDetailsService
    {
        private readonly SqlDataAccess _conn;
        public DocumentDetailsService(SqlDataAccess conn)
        {
            _conn = conn;
        }
        public async Task DeleteDocumentDetailAsync(DocumentDetailRecord item)
        {
            var record = new DocumentDetailRecord
            {
                ID = item.ID
            };

            await _conn
                .DeleteAsync(record)
                .ConfigureAwait(false);
        }
        
        public async Task InsertDocumentDetailAsync(DocumentDetailRecord item)
        {
            var record = new DocumentDetailRecord
            {
                DocumentID = item.DocumentID,
                DocumentDateOut = item.DocumentDateOut?.Date,
                DocumentDateIn = item.DocumentDateIn?.Date,
                Quantity = item.Quantity,
                EquipmentID = item.EquipmentID,
                StatusID = item.StatusID,
                IssueDescription = item.IssueDescription,
                Created = DateTime.Now
            };

            await _conn
                .InsertWithInt64IdentityAsync(record)
                .ConfigureAwait(false);
        }

        public async Task UpdateDocumentDetailAsync(DocumentDetailRecord item)
        {
            var record = new DocumentDetailRecord
            {
                ID = item.ID,
                DocumentID = item.DocumentID,
                DocumentDateOut = item.DocumentDateOut?.Date,
                DocumentDateIn = item.DocumentDateIn?.Date,
                Quantity = item.Quantity,
                EquipmentID = item.EquipmentID,
                Created = DateTime.Now
            };

            await _conn
                .UpdateAsync(record)
                .ConfigureAwait(false);
        }
        public async Task<IEnumerable<DocumentDetailRecord>> GetDocumentDetailsAsync(int docId) =>
            await _conn
                .DocumentDetailsRecords
                .Where(x => x.DocumentID == docId)
                .ToListAsync();
        public async Task<IEnumerable<DocumentDetailRecord>> GetDocumentDetailsListAsync() =>
            await _conn
                .DocumentDetailsRecords
                .ToListAsync();
    }
}
