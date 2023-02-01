using FluentMigrator;
using RepairEquipment.Data;
using RepairEquipment.Migrations.Interfaces;
using static RepairEquipment.Data.Columns;

namespace RepairEquipment.Migrations._20220727_Initial
{
    internal sealed class DocumentStatusMigration : ISubMigration
    {
        private const string TableName = Tables.DocumentStatus;

        public void Up(Migration migration)
        {
            migration.Create.Table(TableName)
                .WithColumn(DocumentStatus.Id).AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn(DocumentStatus.Name).AsString(30).NotNullable()
                .WithColumn(DocumentStatus.Created).AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime);

            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Pieņemts", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Gaida detaļu", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Uzsākts darbs", Created = DateTime.Now });
            migration.Insert.IntoTable(TableName)
                    .Row(new { Name = "Pabeigts", Created = DateTime.Now });
        }
        public void Down(Migration migration)
        {
            migration.Delete.Table(TableName);
        }
    }
}
