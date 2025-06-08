using Microsoft.Extensions.DependencyInjection;
using Pokemon.Application.MestrePokemon.UseCases;
using Pokemon.Application.Pokemons.UseCases;

namespace Pokemon.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<GetPokemonListUseCase>();
            services.AddScoped<GetPokemonDetailUseCase>();
            services.AddScoped<CapturePokemonUseCase>();
            services.AddScoped<GetCapturedPokemonsPagedUseCase>();

            services.AddScoped<AddMestrePokemonUseCase>();
            services.AddScoped<DeleteMestrePokemonUseCase>();
            services.AddScoped<GetMestrePokemonByIdUseCase>();
            services.AddScoped<GetMestrePokemonsPagedUseCase>();
            services.AddScoped<UpdateMestrePokemonUseCase>();

            return services;
        }
    }
}
