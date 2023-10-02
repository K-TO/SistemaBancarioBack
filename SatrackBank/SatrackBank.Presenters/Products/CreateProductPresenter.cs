using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Product;

namespace SatrackBank.Presenters.Products
{
    public class CreateProductPresenter : ICreateProductOutputPort, IPresenter<BasicResponse>
    {
        public BasicResponse Content { get; private set; }

        public Task Handle(BasicResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
