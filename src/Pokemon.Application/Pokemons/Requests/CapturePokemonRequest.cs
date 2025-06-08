namespace Pokemon.Application.Pokemons.Requests
{
    public class CapturePokemonRequest
    {
        public string Name { get; set; } = string.Empty;
        public Guid MestrePokemonId { get; set; }
    }
}
