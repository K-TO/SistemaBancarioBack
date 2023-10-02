using SatrackBank.Entities.Enums;
using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Entities.Interfaces
{
    public interface IReportRepository
    {
        /// <summary>
        /// Get average for customer balance and type.
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        List<AverageBalanceReport> MakeAverageBalanceReport(ProductType? productType);

        /// <summary>
        /// Get top 10 for customers with more balance for type.
        /// </summary>
        /// <param name="productType"></param>
        /// <returns></returns>
        TopCustomersBalanceReport MakeCustomerBalanceReport(ProductType? productType);
    }
}
