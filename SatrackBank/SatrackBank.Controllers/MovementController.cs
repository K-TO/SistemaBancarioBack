using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Presenters.Movement;
using SatrackBank.UseCasesPorts.Movements;

namespace SatrackBank.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class MovementController
    {
        private readonly IGetMovementsInputPort _inputPort;
        private readonly IGetMovementsOutputPort _outputPort;

        public MovementController(IGetMovementsInputPort inputPort,
            IGetMovementsOutputPort outputPort)
        {
            _inputPort = inputPort;
            _outputPort = outputPort;
        }

        [HttpGet("get-movements")]
        public async Task<List<Movement>> GetMovements(string customerId)
        {
            await _inputPort.Handle(customerId);
            var presenter = _outputPort as GetMovementsPresenter;
            return presenter.Content;
        }
        
    }
}
