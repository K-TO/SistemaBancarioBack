using SatrackBank.Entities.Enums;

namespace SatrackBank.UseCasesPorts.Report
{
    public interface IReportTopCustomersInputPort
    {
        Task Handle(ProductType? productType);
    }
}
