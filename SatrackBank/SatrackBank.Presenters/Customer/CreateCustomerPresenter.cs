using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Customer;

namespace SatrackBank.Presenters.Customer
{
    public class CreateCustomerPresenter : ICreateCustomerOutputPort, IPresenter<BasicResponse>
    {
        public BasicResponse Content { get; private set; }

        public Task Handle(BasicResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
