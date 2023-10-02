using SatrackBank.UseCasesDTOs.Product;

namespace SatrackBank.UseCasesPorts.Product
{
    public interface ICancelProductInputPort
    {
        Task Handle(CancelProductParams cancelProductParams);
    }
}
