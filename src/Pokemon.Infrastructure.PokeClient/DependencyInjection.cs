using Microsoft.Extensions.DependencyInjection;
using Pokemon.Domain.Contracts;
using Refit;

namespace Pokemon.Infrastructure.PokeClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPokeClient(this IServiceCollection services)
        {
            services.AddRefitClient<IPokeApiRefit>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://pokeapi.co/api/v2/"));

            services.AddScoped<IPokemonService, PokemonService>();

            return services;
        }
    }
}
