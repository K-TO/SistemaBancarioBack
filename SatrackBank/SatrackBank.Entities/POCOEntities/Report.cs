using SatrackBank.Entities.Enums;

namespace SatrackBank.Entities.POCOEntities
{
    public class Report
    {
        public string CustomerId { get; set; }
        public string Name { get; set; }
        public CustomerType CustomerType { get; set; }
        public ProductType ProductType { get; set; }
        public double Balance { get; set; }
    }

    public class AverageBalanceReport
    {
        public ProductType ProductType { get; set; }
        public double AverageBalance { get; set; }
    }

    public class TopCustomersBalanceReport
    {
        public List<Report> TopForCDT { get; set; }
        public List<Report> TopForSavings { get; set; }
        public List<Report> TopForCurent { get; set; }
    }
}
