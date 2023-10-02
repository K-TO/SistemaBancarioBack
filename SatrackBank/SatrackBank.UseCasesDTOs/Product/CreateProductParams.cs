using SatrackBank.Entities.Enums;

namespace SatrackBank.UseCasesDTOs.Product
{
    public class CreateProductParams
    {
        public string CustomerId { get; set; }
        public ProductType ProductType { get; set; }
        public double Interest { get; set; }
        public double CurrentBalance { get; set; }
    }
}
