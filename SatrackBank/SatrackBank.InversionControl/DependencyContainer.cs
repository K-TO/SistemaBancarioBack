using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SatrackBank.Entities.Interfaces;
using SatrackBank.Presenters.Auth;
using SatrackBank.Presenters.Customer;
using SatrackBank.Presenters.Movement;
using SatrackBank.Presenters.Products;
using SatrackBank.Presenters.Report;
using SatrackBank.Presenters.Simulator;
using SatrackBank.Repositories.EFCore.DataContext;
using SatrackBank.Repositories.EFCore.Repositories;
using SatrackBank.Repositories.EFCore.Utils;
using SatrackBank.UseCases.Auth;
using SatrackBank.UseCases.Common.Validator.Auth;
using SatrackBank.UseCases.Common.Validator.Customer;
using SatrackBank.UseCases.Common.Validator.Product;
using SatrackBank.UseCases.Common.Validator.Simulator;
using SatrackBank.UseCases.Customers;
using SatrackBank.UseCases.Movements;
using SatrackBank.UseCases.Products;
using SatrackBank.UseCases.Report;
using SatrackBank.UseCases.Simulator;
using SatrackBank.UseCasesPorts.Auth;
using SatrackBank.UseCasesPorts.Customer;
using SatrackBank.UseCasesPorts.Movements;
using SatrackBank.UseCasesPorts.Product;
using SatrackBank.UseCasesPorts.Report;
using SatrackBank.UseCasesPorts.Simulator;

namespace SatrackBank.InversionControl
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddSatrackBankServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //DbContext
            services.AddDbContext<SatrackBankContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SatrackBankDB"))
            );

            //Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICustomerProductRepository, CustomerProductRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Ports
            services.AddScoped<ICreateProductInputPort, CreateProductInteractor>();
            services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();

            services.AddScoped<ICancelProductInputPort, CancelProductInteractor>();
            services.AddScoped<ICancelProductOutputPort, CancelProductPresenter>();

            services.AddScoped<ISimulatorInputPort, SimulatorInteractor>();
            services.AddScoped<ISimulatorOutputPort, SimulatorPresenter>();

            services.AddScoped<IReportAverageBalanceInputPort, ReportAverageBalanceInteractor>();
            services.AddScoped<IReportAverageBalanceOutputPort, ReportAverageBalancePresenter>();

            services.AddScoped<IReportTopCustomersInputPort, ReportTopCustomersInteractor>();
            services.AddScoped<IReportTopCustomersOutputPort, ReportTopCustomersPresenter>();

            services.AddScoped<ICreateCustomerInputPort, CreateCustomerInteractor>();
            services.AddScoped<ICreateCustomerOutputPort, CreateCustomerPresenter>();

            services.AddScoped<IGetCustomerProductsInputPort, GetCustomerProductsInteractor>();
            services.AddScoped<IGetCustomerProductsOutputPort, GetCustomerProductsPresenter>();

            services.AddScoped<IAuthInputPort, LoginInteractor>();
            services.AddScoped<IAuthOutputPort, LoginPresenter>();

            services.AddScoped<IGetMovementsInputPort, GetMovementsInteractor>();
            services.AddScoped<IGetMovementsOutputPort, GetMovementsPresenter>();

            services.AddScoped<IJwtUtils, JwtUtils>();

            //Validators
            services.AddValidatorsFromAssembly(typeof(CreateProductValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(CancelProductValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(SimulatorValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(CreateCustomerValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(LoginValidator).Assembly);

            return services;
        }
    }
}
