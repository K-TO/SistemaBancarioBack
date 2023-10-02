namespace SatrackBank.UseCasesPorts.Customer
{
    public interface IGetCustomerProductsOutputPort
    {
        Task Handle(List<Entities.POCOEntities.Product> products);
    }
}
