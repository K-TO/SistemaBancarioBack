using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatrackBank.Presenters.Simulator;
using SatrackBank.UseCasesDTOs.Simulator;
using SatrackBank.UseCasesPorts.Simulator;

namespace SatrackBank.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class SimulatorController
    {
        private readonly ISimulatorInputPort _simulatorInputPort;
        private readonly ISimulatorOutputPort _simulatorOutputPort;

        public SimulatorController(ISimulatorInputPort simulatorInputPort,
            ISimulatorOutputPort simulatorOutputPort)
        {
            _simulatorInputPort = simulatorInputPort;
            _simulatorOutputPort = simulatorOutputPort; 
        }

        [HttpPost("make-simulation")]
        public async Task<SimulatorResponse> MakeSimulation(SimulatorParams simulatorParams)
        {
            await _simulatorInputPort.Handle(simulatorParams);
            var presenter = _simulatorOutputPort as SimulatorPresenter;
            return presenter.Content;
        }
    }
}
