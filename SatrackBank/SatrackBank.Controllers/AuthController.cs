using Microsoft.AspNetCore.Mvc;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.Presenters.Auth;
using SatrackBank.UseCasesDTOs.Auth;
using SatrackBank.UseCasesPorts.Auth;

namespace SatrackBank.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController
    {
        private readonly IAuthInputPort _authInputPort;
        private readonly IAuthOutputPort _authOutputPort;

        public AuthController(IAuthInputPort authInputPort,
            IAuthOutputPort authOutputPort)
        {
            _authInputPort = authInputPort;
            _authOutputPort = authOutputPort;
        }

        [HttpPost("login")]
        public async Task<AuthenticationResponse> Login(LoginParams loginParams)
        {
            await _authInputPort.Handle(loginParams);
            var presenter = _authOutputPort as LoginPresenter;
            return presenter.Content;
        }
    }
}
