using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class EquipmentMigration : ISubMigration
    {
        private const string TableName = Tables.Equipment;
        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(Equipment.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(Equipment.Brand).AsString(200).NotNullable()
                .WithColumn(Equipment.Model).AsString(200).NotNullable()
                .WithColumn(Equipment.TypeId).AsInt32().NotNullable().ForeignKey(Tables.EquipmentType, EquipmentType.Id)
                .WithColumn(Equipment.SerialNumber).AsString(20).Nullable()
                .WithColumn(Equipment.PurchaseDate).AsDateTime().NotNullable()
                .WithColumn(Equipment.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Create.Index($"IX_{TableName}_{Equipment.TypeId}")
                .OnTable(TableName)
                .OnColumn(Equipment.TypeId).Ascending();
        }

        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
