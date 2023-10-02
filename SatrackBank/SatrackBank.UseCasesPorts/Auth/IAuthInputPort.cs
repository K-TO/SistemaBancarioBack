using SatrackBank.UseCasesDTOs.Auth;

namespace SatrackBank.UseCasesPorts.Auth
{
    public interface IAuthInputPort
    {
        Task Handle(LoginParams loginParams);
    }
}
