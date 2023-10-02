using FluentValidation;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCases.Common.Validator;
using SatrackBank.UseCasesDTOs.Auth;
using SatrackBank.UseCasesPorts.Auth;

namespace SatrackBank.UseCases.Auth
{
    public class LoginInteractor : IAuthInputPort
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEnumerable<IValidator<LoginParams>> _validators;
        private readonly IJwtUtils _jwtUtils;
        private readonly IAuthOutputPort _outputPort;

        public LoginInteractor(ICustomerRepository customerRepository,
            IEnumerable<IValidator<LoginParams>> validators,
            IJwtUtils jwtUtils,
            IAuthOutputPort outputPort)
        {
            _customerRepository = customerRepository;
            _validators = validators;
            _jwtUtils = jwtUtils;
            _outputPort = outputPort;
        }

        public async Task Handle(LoginParams loginParams)
        {
            await Validator<LoginParams>.Validate(loginParams, _validators);

            AuthenticationResponse response = new();

            Customer customer = await _customerRepository.Authenticate(loginParams.User, loginParams.Password);

            if (customer != null)
            {
                response.Id = customer.Id;
                response.Identification = customer.Identification;
                response.Name = customer.Name;
                response.Token = _jwtUtils.GenerateToken(customer);
            }
            else
            {
                response.Message = "El usuario y/o la contraseña, no son validos.";
            }
            await _outputPort.Handle(response);
        }
    }
}
