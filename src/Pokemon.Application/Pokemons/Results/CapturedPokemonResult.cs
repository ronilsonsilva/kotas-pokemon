namespace Pokemon.Application.Pokemons.Results
{
    public class CapturedPokemonResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid MestrePokemonId { get; set; }
    }
}
