using System;
using Imdb.Application.AuthServices;
using Imdb.Domain.AuthAggregate.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Imdb.Application.DependencyInjection
{
    public static class ImdbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
