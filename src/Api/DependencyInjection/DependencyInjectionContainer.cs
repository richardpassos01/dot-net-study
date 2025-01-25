using Microsoft.Extensions.DependencyInjection;
using src.Application.Interfaces;
using src.Application.UseCases;
using src.Infrastructure.Adapters;
using src.Infrastructure.Repositories;


namespace src.Api.DependencyInjection
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetLoan>();
            services.AddScoped<LoanOrigination>();
            services.AddScoped<LoanApplicationRepository>();

            services.AddHttpClient<ILoanManagementAdapter, LoanManagementAdapter>();
            return services;
        }
    }
}