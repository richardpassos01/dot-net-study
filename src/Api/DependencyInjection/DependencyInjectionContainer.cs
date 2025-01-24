using Microsoft.Extensions.DependencyInjection;
using src.Application.Interfaces;
using src.Application.UseCases;
using src.Infrastructure.Adapters;

namespace src.Api.DependencyInjection
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetLoan>();
            services.AddHttpClient<ILoanManagementAdapter, LoanManagementAdapter>();
            return services;
        }
    }
}