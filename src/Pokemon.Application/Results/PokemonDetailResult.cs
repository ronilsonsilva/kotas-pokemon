namespace Pokemon.Application.Results
{
    public class PokemonDetailResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public bool IsDefault { get; set; }
        public List<PokemonAbilityResult> Abilities { get; set; } = new();
        public List<PokemonTypeResult> Types { get; set; } = new();
        public List<PokemonStatResult> Stats { get; set; } = new();
        public List<PokemonMoveResult> Moves { get; set; } = new();
        public string? SpriteFrontDefault { get; set; }
    }
}
