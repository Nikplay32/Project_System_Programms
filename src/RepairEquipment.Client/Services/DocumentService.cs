using LinqToDB;
using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services.Interfaces;
using RepairEquipment.Shared.Models.Data;
using RepairEquipment.Shared.Models.Export;

namespace RepairEquipment.Client.Services
{
    public sealed class DocumentService : IDocumentService
    {
        private readonly SqlDataAccess _conn;

        private readonly IUtilsService _utilsService;
        public DocumentService(SqlDataAccess conn, IUtilsService utilsService)
        {
            _conn = conn;
            _utilsService = utilsService;
        }
        public async Task DeleteDocumentAsync(DocumentRecord item)
        {
            var record = new DocumentRecord
            {
                ID = item.ID
            };

            await _conn
                .DeleteAsync(record)
                .ConfigureAwait(false);
        }
        public async Task<List<DocumentRecord>> GetDocumentsListAsync() =>
            await _conn
                .DocumentsRecords
                .ToListAsync();
        public async Task InsertDocumentAsync(DocumentRecord item)
        {
            var record = new DocumentRecord
            {
                ID = item.ID,
                DocumentNumber = item.DocumentNumber,
                ClientID = item.ClientID,
                EmployeeID = item.EmployeeID,
                Created = DateTime.Now
            };

            await _conn
                .InsertAsync(record)
                .ConfigureAwait(false);
        }
        public async Task UpdateDocumentAsync(DocumentRecord item)
        {
            var record = new DocumentRecord
            {
                ID = item.ID,
                DocumentNumber = item.DocumentNumber,
                ClientID = item.ClientID,
                EmployeeID = item.EmployeeID,
                Created = DateTime.Now
            };

            await _conn
                .UpdateAsync(record)
                .ConfigureAwait(false);
        }
        public async Task<int> GetDocumentClientByNameAsync(string name) =>
            await _conn
                .ClientsRecords
                .Where(x => x.Name.Contains(name))
                .Select(x => x.ID)
                .FirstOrDefaultAsync();

        public async Task<int> GetDocumentEmployeeByNameAsync(string code) =>
            await _conn
                .EmployeesRecords
                .Where(x => x.Code.Contains(code))
                .Select(x => x.ID)
                .FirstOrDefaultAsync();
        public async Task<IEnumerable<DocExportModel>> GetDocumentsAsync(string? search)
        {
            IEnumerable<DocExportModel> res;

            if (!string.IsNullOrEmpty(search))
            {
                var clientId = await GetDocumentClientByNameAsync(search);
                var employeeId = await GetDocumentEmployeeByNameAsync(search);

                res = _conn.DocumentsRecords
                    .SelectMany(d => _conn.DocumentDetailsRecords.InnerJoin(ddd => ddd.DocumentID == d.ID),
                        (d, dd) => new { d, dd })
                    .SelectMany(@t => _conn.ClientsRecords.LeftJoin(cd => cd.ID == @t.d.ClientID),
                        (@t, c) => new { @t, c })
                    .Where(@t =>
                        @t.@t.d.ClientID == clientId || @t.@t.d.EmployeeID == employeeId)
                    .Select(@t => new DocExportModel
                    {
                        DocumentNumber = @t.@t.d.DocumentNumber,
                        ClientId = @t.@t.d.ClientID,
                        ClientRegistrationNr = @t.c.RegistrationNr,
                        Client = @t.c.Name,
                        EmployeeId = @t.@t.d.EmployeeID,
                        DocumentDateOut = @t.@t.dd.DocumentDateOut,
                        DocumentDateIn = @t.@t.dd.DocumentDateIn,
                        EquipmentId = @t.@t.dd.EquipmentID,
                        Quantity = @t.@t.dd.Quantity
                    }) ;

            }
            else
            {
                res = _conn.DocumentDetailsRecords
                    .SelectMany(dd => _conn.DocumentsRecords
                            .InnerJoin(ddd => ddd.ID == dd.DocumentID),
                    (dd, d) => new DocExportModel
                    {
                        ClientId = d.ClientID,
                        EmployeeId = d.EmployeeID,
                        DocumentDateOut = dd.DocumentDateOut,
                        DocumentDateIn = dd.DocumentDateIn,
                        EquipmentId = dd.EquipmentID,
                        Quantity = dd.Quantity,
                    });
            }
            return res.ToList();
        }

    }
}
