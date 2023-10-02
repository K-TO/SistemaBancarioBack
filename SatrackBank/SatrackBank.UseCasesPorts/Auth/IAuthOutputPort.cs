using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.UseCasesPorts.Auth
{
    public interface IAuthOutputPort
    {
        Task Handle(AuthenticationResponse response);
    }
}
