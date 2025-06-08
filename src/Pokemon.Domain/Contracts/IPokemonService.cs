using Pokemon.Domain.Entities;

namespace Pokemon.Domain.Contracts
{
    public interface IPokemonService
    {
        /// <summary>
        /// Obtém uma lista paginada de pokémons.
        /// </summary>
        /// <param name="offset">Índice inicial da página.</param>
        /// <param name="limit">Quantidade de itens por página.</param>
        /// <returns>Lista paginada de pokémons.</returns>
        Task<PokemonList> GetPokemonListAsync(int offset = 0, int limit = 20);

        /// <summary>
        /// Obtém os detalhes de um pokémon pelo nome.
        /// </summary>
        /// <param name="name">Nome do pokémon.</param>
        /// <returns>Detalhes do pokémon ou null se não encontrado.</returns>
        Task<PokemonEntity?> GetPokemonByNameAsync(string name);
    }
}
