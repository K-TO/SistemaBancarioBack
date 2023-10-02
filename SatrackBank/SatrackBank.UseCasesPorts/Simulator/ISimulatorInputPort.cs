using SatrackBank.UseCasesDTOs.Simulator;

namespace SatrackBank.UseCasesPorts.Simulator
{
    public interface ISimulatorInputPort
    {
        Task Handle(SimulatorParams simulatorParams);
    }
}
