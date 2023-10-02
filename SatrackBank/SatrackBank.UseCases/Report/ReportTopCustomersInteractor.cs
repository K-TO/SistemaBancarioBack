using SatrackBank.Entities.Enums;
using SatrackBank.Entities.Exceptions;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Report;

namespace SatrackBank.UseCases.Report
{
    public class ReportTopCustomersInteractor : IReportTopCustomersInputPort
    {
        private readonly IReportRepository _reportRepository;
        private readonly IReportTopCustomersOutputPort _outputPort;

        public ReportTopCustomersInteractor(IReportRepository reportRepository,
            IReportTopCustomersOutputPort outputPort)
        {
            _reportRepository = reportRepository;
            _outputPort = outputPort;
        }

        public async Task Handle(ProductType? productType)
        {
            TopCustomersBalanceReport report;
            try
            {
                report = _reportRepository.MakeCustomerBalanceReport(productType);
            }
            catch (Exception ex)
            {
                throw new GeneralException("Error al generar los datos del reporte de top de clientes.", ex.Message);
            }
            await _outputPort.Handle(report);
        }
    }
}
