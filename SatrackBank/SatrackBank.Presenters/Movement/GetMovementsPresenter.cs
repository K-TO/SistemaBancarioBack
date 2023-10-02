using SatrackBank.UseCasesPorts.Movements;
using entity = SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Presenters.Movement
{
    public class GetMovementsPresenter : IGetMovementsOutputPort, IPresenter<List<entity.Movement>>
    {
        public List<entity.Movement> Content { get; private set; }

        public Task Handle(List<entity.Movement> response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
