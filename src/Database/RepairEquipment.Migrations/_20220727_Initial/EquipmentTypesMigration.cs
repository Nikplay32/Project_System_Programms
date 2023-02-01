using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class EquipmentTypesMigration : ISubMigration
    {
        private const string TableName = Tables.EquipmentType;

        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(EquipmentType.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(EquipmentType.Name).AsString(30).NotNullable().WithDefaultValue(0)
                .WithColumn(EquipmentType.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Augstas", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Karstās", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Svēršanas", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Kafijas aparāti", Created = DateTime.Now });
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
