using SatrackBank.Entities.Enums;

namespace SatrackBank.Entities.POCOEntities
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public DocumentType DocumentType { get; set; }
        public string CellPhone { get; set; }
        public CustomerType CustomerType { get; set; }
        public string LegalRepresentName { get; set; }
        public string LegalRepresentPhone { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
    }
}
