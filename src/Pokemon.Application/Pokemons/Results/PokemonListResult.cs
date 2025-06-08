namespace Pokemon.Application.Pokemons.Results
{
    public class PokemonListResult
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public List<PokemonListItemResult> Results { get; set; } = new();
    }
}
