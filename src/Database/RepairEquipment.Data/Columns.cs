namespace RepairEquipment.Data
{
    public static class Columns
    {
        public static class Employee
        {
            public const string Id = "ID";
            public const string Code = "Code";
            public const string Name = "Name";
            public const string Surname = "Surname";
            public const string Phone = "Phone";
            public const string Email = "Email";
            public const string Created = "Created";
        }
        public static class EquipmentType
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string Created = "Created";
        }
        public static class Equipment
        {
            public const string Id = "ID";
            public const string TypeId = "TypeID";
            public const string Brand = "Brand";
            public const string Model = "Model";
            public const string SerialNumber = "SerialNumber";
            public const string PurchaseDate = "PurchaseDate";
            public const string Created = "Created";
        }
        public static class EquipmentHistory
        {
            public const string Id = "ID";
            public const string Brand = "Brand";
            public const string Model = "Model";
            public const string EquipmentType = "EquipmentType";
            public const string Client = "Client";
            public const string Employee = "Employee";
            public const string DocumentNumber = "DocumentNumber";
            public const string DocumentDateOut = "DocumentDateOut";
            public const string DocumentDateIn = "DocumentDateIn";
            public const string Quantity = "Quantity";
            public const string Created = "Created";
        }
        public static class Document
        {
            public const string Id = "ID";
            public const string DocumentNumber = "DocumentNumber";
            public const string ClientId = "ClientID";
            public const string EmployeeId = "EmployeeID";
            public const string Created = "Created";
        }
        public static class DocumentDetail
        {
            public const string Id = "ID";
            public const string DocumentId = "DocumentID";
            public const string EquipmentId = "EquipmentID";
            public const string DocumentDateOut = "DocumentDateOut";
            public const string DocumentDateIn = "DocumentDateIn";
            public const string Quantity = "Quantity";
            public const string StatusId = "StatusID";
            public const string IssueDescription = "IssueDescription";
            public const string Created = "Created";
        }
        public static class DocumentStatus
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string Created = "Created";
        }
        public static class Client
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string RegistrationNr = "RegistrationNr";
            public const string LegalAddress = "LegalAddress";
            public const string Phone = "Phone";
            public const string Email = "Email";
            public const string Created = "Created";
        }

        public static class Location
        {
            public const string Id = "ID";
            public const string Name = "Name";
            public const string Created = "Created";
        }

    }
}