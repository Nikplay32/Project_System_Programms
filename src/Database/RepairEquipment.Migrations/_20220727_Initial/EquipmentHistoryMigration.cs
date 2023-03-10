using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class EquipmentHistoryMigration : ISubMigration
    {
        private const string TableName = Tables.EquipmentHistory;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(EquipmentHistory.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(EquipmentHistory.Brand).AsString(50).NotNullable()
                .WithColumn(EquipmentHistory.Model).AsString(50).NotNullable()
                .WithColumn(EquipmentHistory.EquipmentType).AsString(30).NotNullable()
                .WithColumn(EquipmentHistory.Client).AsString(50).NotNullable()
                .WithColumn(EquipmentHistory.Employee).AsString(50).NotNullable()
                .WithColumn(EquipmentHistory.DocumentNumber).AsString(50).NotNullable()
                .WithColumn(EquipmentHistory.DocumentDateOut).AsDateTime().NotNullable()
                .WithColumn(EquipmentHistory.DocumentDateIn).AsDateTime().Nullable()
                .WithColumn(EquipmentHistory.Quantity).AsDecimal(7, 2).NotNullable()
                .WithColumn(EquipmentHistory.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
