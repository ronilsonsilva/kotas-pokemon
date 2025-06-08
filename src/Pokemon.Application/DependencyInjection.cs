using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.UseCases;

namespace Pokemon.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<GetPokemonListUseCase>();
            services.AddScoped<GetPokemonDetailUseCase>();

            return services;
        }
    }
}
