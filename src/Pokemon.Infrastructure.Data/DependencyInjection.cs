using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pokemon.Domain.Contracts.Repositories;
using Pokemon.Infrastructure.Data.Context;
using Pokemon.Infrastructure.Data.Repositories;

namespace Pokemon.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PokemonDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
