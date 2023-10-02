using FluentValidation;
using SatrackBank.Entities.Exceptions;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Entities.POCOEntities;
using SatrackBank.UseCases.Common.Validator;
using SatrackBank.UseCasesDTOs.Customer;
using SatrackBank.UseCasesPorts.Customer;
using Bcr = BCrypt.Net;

namespace SatrackBank.UseCases.Customers
{
    public class CreateCustomerInteractor : ICreateCustomerInputPort
    {
        private readonly ICreateCustomerOutputPort _outputPort;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEnumerable<IValidator<CreateCustomerParams>> _validators;

        public CreateCustomerInteractor(ICreateCustomerOutputPort outputPort,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<CreateCustomerParams>> validators)
        {
            _outputPort = outputPort;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _validators = validators;
        }

        public async Task Handle(CreateCustomerParams customerParams)
        {
            await Validator<CreateCustomerParams>.Validate(customerParams, _validators);
            BasicResponse response = new();
            bool idExists = _customerRepository.IdentificationExists(customerParams.Identification);
            if (!idExists)
            {
                Customer customer = new Customer
                {
                    Id = Guid.NewGuid().ToString(),
                    CellPhone = customerParams.CellPhone,
                    CreationDate = DateTime.Now,
                    CustomerType = customerParams.CustomerType,
                    DocumentType = customerParams.DocumentType,
                    Identification = customerParams.Identification,
                    LegalRepresentName = customerParams?.LegalRepresentName,
                    LegalRepresentPhone = customerParams?.LegalRepresentPhone,
                    Name = customerParams.Name,
                    Password = Bcr.BCrypt.HashPassword(customerParams.Password)
                };

                _customerRepository.Create(customer);

                try
                {
                    await _unitOfWork.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new GeneralException("Error al crear el cliente.", ex.Message);
                }
                response.Message = "Cliente registrado satisfactoriamente.";
                await _outputPort.Handle(response);
            }
            else
            {
                response.Message = "El número de identificación ya existe.";
                response.HasError = true;
                await _outputPort.Handle(response);
            }
        }
    }
}
