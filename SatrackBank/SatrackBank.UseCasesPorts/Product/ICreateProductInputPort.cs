using SatrackBank.UseCasesDTOs.Product;

namespace SatrackBank.UseCasesPorts.Product
{
    public interface ICreateProductInputPort
    {
        Task Handle(CreateProductParams createProductParams);
    }
}
