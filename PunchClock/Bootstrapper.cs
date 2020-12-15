using Microsoft.Extensions.DependencyInjection;
using PunchClock.Application;
using PunchClock.Domain.Repository;
using PunchClock.Domain.Services;
using PunchClock.Infra.Repository;

namespace PunchClock
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPunchRepository, PunchRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IPunchService, PunchService>();

            return services;
        }
    }
}