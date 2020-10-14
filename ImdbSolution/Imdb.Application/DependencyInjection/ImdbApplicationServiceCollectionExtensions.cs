using System;
using Imdb.Application.AuthServices;
using Imdb.Application.MovieServices;
using Imdb.Domain.AuthAggregate.Services;
using Imdb.Domain.MovieAggregate.Services;
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
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IVoteService, VoteService>();

            return services;
        }
    }
}
