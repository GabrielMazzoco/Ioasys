using System;
using Imdb.Adapter.Data;
using Imdb.Adapter.Data.Repositories;
using Imdb.Adapter.Data.UoW;
using Imdb.Domain.AuthAggregate.Repositories;
using Imdb.Domain.MovieAggregate.Repositories;
using Imdb.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Imdb.Adapter.DependencyInjection
{
    public static class ImdbAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddAdapter(this IServiceCollection services
            , IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<DataContext>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();

            services.AddDbContext<DataContext>(x =>
                x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
