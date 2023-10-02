using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCasesPorts.Auth;

namespace SatrackBank.Presenters.Auth
{
    public class LoginPresenter : IAuthOutputPort, IPresenter<AuthenticationResponse>
    {
        public AuthenticationResponse Content { get; private set; }

        public Task Handle(AuthenticationResponse response)
        {
            Content = response;
            return Task.CompletedTask;
        }
    }
}
