using SatrackBank.Entities.Enums;
using SatrackBank.Entities.Exceptions;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Report;

namespace SatrackBank.UseCases.Report
{
    public class ReportAverageBalanceInteractor : IReportAverageBalanceInputPort
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportAverageBalanceOutputPort _outputPort;

        public ReportAverageBalanceInteractor(IReportRepository reportRepository,
            IReportAverageBalanceOutputPort outputPort)
        {
            _reportRepository = reportRepository;
            _outputPort = outputPort;
        }

        public async Task Handle(ProductType? productType)
        {
            List<AverageBalanceReport> averageBalance;
            try
            {
                averageBalance = _reportRepository.MakeAverageBalanceReport(productType);
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al obtener datos de reporte de balance promedio.", ex.Message);
            }
            await _outputPort.Handle(averageBalance);
        }
    }
}