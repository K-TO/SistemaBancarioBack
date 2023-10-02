using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SatrackBank.Entities.Enums;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Presenters.Report;
using SatrackBank.UseCasesPorts.Report;

namespace SatrackBank.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class ReportController
    {
        private readonly IReportTopCustomersInputPort _reportTopCustomersInputPort;
        private readonly IReportTopCustomersOutputPort _reportTopCustomersOutputPort;
        private readonly IReportAverageBalanceInputPort _reportAverageBalanceInputPort;
        private readonly IReportAverageBalanceOutputPort _reportAverageBalanceOutputPort;

        public ReportController(IReportTopCustomersInputPort reportTopCustomersInputPort,
            IReportTopCustomersOutputPort reportTopCustomersOutputPort,
            IReportAverageBalanceInputPort reportAverageBalanceInputPort,
            IReportAverageBalanceOutputPort reportAverageBalanceOutputPort)
        {
            _reportAverageBalanceInputPort = reportAverageBalanceInputPort;
            _reportAverageBalanceOutputPort = reportAverageBalanceOutputPort;
            _reportTopCustomersInputPort = reportTopCustomersInputPort;
            _reportTopCustomersOutputPort = reportTopCustomersOutputPort;
        }

        [HttpPost("report-averagebalance")]
        public async Task<List<AverageBalanceReport>> ReportAverageBalance(ProductType? productType)
        {
            await _reportAverageBalanceInputPort.Handle(productType);
            var presenter = _reportAverageBalanceOutputPort as ReportAverageBalancePresenter;
            return presenter.Content;
        }

        [HttpPost("report-topcustomers")]
        public async Task<TopCustomersBalanceReport> ReportTopCustomers(ProductType? productType)
        {
            await _reportTopCustomersInputPort.Handle(productType);
            var presenter = _reportTopCustomersOutputPort as ReportTopCustomersPresenter;
            return presenter.Content;
        }
    }
}
