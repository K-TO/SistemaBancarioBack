using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.UseCasesPorts.Customer
{
    public interface ICreateCustomerOutputPort
    {
        Task Handle(BasicResponse response);
    }
}
