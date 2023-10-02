namespace SatrackBank.UseCasesPorts.Customer
{
    public interface IGetCustomerProductsInputPort
    {
        Task Handle(string customerId);
    }
}
