using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Application.Extensions;

public static class AplicattionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cf => cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}