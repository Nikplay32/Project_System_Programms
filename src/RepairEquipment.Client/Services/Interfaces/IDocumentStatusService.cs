using RepairEquipment.Shared.Models.Data;

namespace RepairEquipment.Client.Services.Interfaces
{
    public interface IDocumentStatusService
    {
        public Task<List<DocumentStatusRecord>> GetDocumentStatusListAsync();
    }
}
