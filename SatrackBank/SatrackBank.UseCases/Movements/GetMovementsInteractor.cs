using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Movements;

namespace SatrackBank.UseCases.Movements
{
    public class GetMovementsInteractor : IGetMovementsInputPort
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IGetMovementsOutputPort _outputPort;

        public GetMovementsInteractor(IMovementRepository movementRepository,
            IGetMovementsOutputPort outputPort)
        {
            _movementRepository = movementRepository;
            _outputPort = outputPort;
        }

        public async Task Handle(string customerId)
        {
            List<Movement> movements = _movementRepository.GetMovementsByCustomer(customerId);
            await _outputPort.Handle(movements);
        }
    }
}
