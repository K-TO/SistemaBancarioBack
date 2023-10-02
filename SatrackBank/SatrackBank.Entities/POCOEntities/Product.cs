using SatrackBank.Entities.Enums;

namespace SatrackBank.Entities.POCOEntities
{
    public class Product
    {
        public string Id { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public ProductType ProductType { get; set; }
        public double CurrentBalance { get; set; }
        public double Interest { get; set; }
        public DateTime CreationDate { get; set; }
    }
}