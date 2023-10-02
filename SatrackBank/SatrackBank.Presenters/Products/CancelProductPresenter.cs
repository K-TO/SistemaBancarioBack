using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Product;

namespace SatrackBank.Presenters.Products
{
    public class CancelProductPresenter : ICancelProductOutputPort, IPresenter<BasicResponse>
    {
        public BasicResponse Content { get; private set; }

        public Task Handle(BasicResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
