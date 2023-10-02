using SatrackBank.UseCasesDTOs.Customer;

namespace SatrackBank.UseCasesPorts.Customer
{
    public interface ICreateCustomerInputPort
    {
        Task Handle(CreateCustomerParams customerParams);
    }
}
