using SatrackBank.UseCasesDTOs.Simulator;

namespace SatrackBank.UseCasesPorts.Simulator
{
    public interface ISimulatorOutputPort
    {
        Task Handle(SimulatorResponse simulatorResponse);
    }
}
