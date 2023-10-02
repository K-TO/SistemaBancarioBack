using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Entities.Interfaces
{
    public interface IMovementRepository
    {
        void Create(Movement movement);
        List<Movement> GetMovementsByCustomer(string customerId);
    }
}
