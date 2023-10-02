using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SatrackBank.Repositories.EFCore.DataContext
{
    public class SatrackContextFactory : IDesignTimeDbContextFactory<SatrackBankContext>
    {
        public SatrackBankContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<SatrackBankContext>();
            OptionBuilder.UseSqlServer("Server=localhost;Database=SatrackBankDev;Trusted_Connection=True;TrustServerCertificate=True;");
            return new SatrackBankContext(OptionBuilder.Options);
        }
    }
}
