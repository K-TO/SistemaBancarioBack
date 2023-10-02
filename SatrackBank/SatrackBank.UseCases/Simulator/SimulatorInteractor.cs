using FluentValidation;
using SatrackBank.Entities.Exceptions;
using SatrackBank.UseCases.Common.Validator;
using SatrackBank.UseCasesDTOs.Simulator;
using SatrackBank.UseCasesPorts.Simulator;

namespace SatrackBank.UseCases.Simulator
{
    public class SimulatorInteractor : ISimulatorInputPort
    {
        private readonly IEnumerable<IValidator<SimulatorParams>> _validators;
        private readonly ISimulatorOutputPort _simulatorOutputPort;

        public SimulatorInteractor(IEnumerable<IValidator<SimulatorParams>> validators,
            ISimulatorOutputPort simulatorOutputPort)
            => (_validators, _simulatorOutputPort) = (validators, simulatorOutputPort);
      
        public async Task Handle(SimulatorParams simulatorParams)
        {
            await Validator<SimulatorParams>.Validate(simulatorParams, _validators);

            SimulatorResponse response = new SimulatorResponse
            {
                Money = simulatorParams.Money,
                TotalInterest = 0,
                TotalMonths = 0,
                TotalDays = 0
            };

            try
            {
                response.TotalMonths = Math.Abs((simulatorParams.BeginDate.Month - simulatorParams.EndDate.Month) + 12 * (simulatorParams.BeginDate.Year - simulatorParams.EndDate.Year));
                TimeSpan days = simulatorParams.EndDate - simulatorParams.BeginDate;
                response.TotalDays = days.Days;

                response.TotalInterest = response.Money * (simulatorParams.Interest / 100) * (days.Days / 365);

            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al generar la simulación.", ex.Message);
            }
            await _simulatorOutputPort.Handle(response);
        }
    }
}
