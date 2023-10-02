using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.Entities.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateToken(Customer user);
        public int? ValidateToken(string token);
    }
}
