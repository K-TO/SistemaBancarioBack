using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.UseCasesPorts.Movements
{
    public interface IGetMovementsOutputPort
    {
        Task Handle(List<Movement> movements);
    }
}
