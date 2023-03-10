using RepairEquipment.Client.DbAccess;
using RepairEquipment.Client.Services;
using RepairEquipment.Client.Services.Interfaces;

namespace RepairEquipment.Utils.ServiceRegistration
{
    public static class ServiceCollectionEx
    {
        public static IServiceCollection AddRepairEquipmentServices(this IServiceCollection @this) =>
            @this
                .AddSqlServices();
        private static IServiceCollection AddSqlServices(this IServiceCollection @this) =>
            @this
                .AddScoped<IClientService, ClientService>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<IEquipmentService, EquipmentService>()
                .AddScoped<IDocumentService, DocumentService>()
                .AddScoped<IDocumentDetailsService, DocumentDetailsService>()
                .AddScoped<IEquipmentTypeService, EquipmentTypeService>()
                .AddScoped<IEquipmentHistoryService, EquipmentHistoryService>()
                .AddScoped<IUtilsService, UtilsService>()
                .AddScoped<ILocationService, LocationService>()
                .AddScoped<IDocumentStatusService, DocumentStatusService>();
    }
}
