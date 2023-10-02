using SatrackBank.UseCasesDTOs.Simulator;
using SatrackBank.UseCasesPorts.Simulator;

namespace SatrackBank.Presenters.Simulator
{
    public class SimulatorPresenter : ISimulatorOutputPort, IPresenter<SimulatorResponse>
    {
        public SimulatorResponse Content { get; private set; }

        public Task Handle(SimulatorResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
