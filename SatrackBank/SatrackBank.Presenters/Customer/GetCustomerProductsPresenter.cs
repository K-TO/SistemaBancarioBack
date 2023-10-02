using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Customer;

namespace SatrackBank.Presenters.Customer
{
    public class GetCustomerProductsPresenter : IGetCustomerProductsOutputPort, IPresenter<List<Product>>
    {
        public List<Product> Content { get; private set; }

        public Task Handle(List<Product> products)
        {
            Content = products;
            return Task.CompletedTask;
        }
    }
}
