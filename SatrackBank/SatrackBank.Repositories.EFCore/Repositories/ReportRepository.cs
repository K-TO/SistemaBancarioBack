using SatrackBank.Entities.Enums;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Repositories.EFCore.DataContext;

namespace SatrackBank.Repositories.EFCore.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly SatrackBankContext _context;

        public ReportRepository(SatrackBankContext context)
        {
            _context = context;
        }

        public List<AverageBalanceReport> MakeAverageBalanceReport(ProductType? productType)
        {
            IQueryable<AverageBalanceReport> products = from prod in _context.Product.Where(x => x.ProductStatus.Equals(ProductStatus.Active)
                                                            && productType.HasValue ? x.ProductType.Equals(productType) : true)
                                                        group prod by new
                                                        {
                                                            prod.ProductType
                                                        } into prods
                                                        select new AverageBalanceReport
                                                        {
                                                            AverageBalance = prods.Average(p => p.CurrentBalance),
                                                            ProductType = prods.Key.ProductType
                                                        };

            return products.ToList();
        }

        public TopCustomersBalanceReport MakeCustomerBalanceReport(ProductType? productType)
        {
            //TO=>K-TO=>Validar si es mas optimo hacer un SP
            TopCustomersBalanceReport report = new TopCustomersBalanceReport();
            if (productType.HasValue)
            {
                switch (productType)
                {
                    case ProductType.Corriente:
                        report.TopForCurent = GetReportByProductType(productType.Value);
                        break;
                    case ProductType.CDT:
                        report.TopForCDT = GetReportByProductType(productType.Value);
                        break;
                    case ProductType.Ahorros:
                        report.TopForSavings = GetReportByProductType(productType.Value);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                report.TopForCDT = GetReportByProductType(ProductType.CDT);
                report.TopForCurent = GetReportByProductType(ProductType.Corriente);
                report.TopForSavings = GetReportByProductType(ProductType.Ahorros);
            }

            return report;
        }

        private List<Report> GetReportByProductType(ProductType productType)
        {
            List<Report> reportBalance = (from prod in _context.Product
                                                   .Where(x => x.ProductStatus.Equals(ProductStatus.Active) && x.ProductType.Equals(productType))
                                          join cp in _context.CustomerProducts on prod.Id equals cp.ProductId
                                          join c in _context.Customer on cp.CustomerId equals c.Id
                                          orderby prod.CurrentBalance descending
                                          select new Report
                                          {
                                              Balance = prod.CurrentBalance,
                                              CustomerId = c.Id,
                                              ProductType = prod.ProductType,
                                              CustomerType = c.CustomerType,
                                              Name = c.Name
                                          })
                                          .Take(10)
                                          .ToList();
            return reportBalance;
        }
    }
}
