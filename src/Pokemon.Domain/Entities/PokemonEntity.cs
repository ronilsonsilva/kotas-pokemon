namespace Pokemon.Domain.Entities
{
    public class PokemonEntity
    {
        public int Id { get; }
        public string Name { get; }
        public int BaseExperience { get; }
        public int Height { get; }
        public int Weight { get; }
        public bool IsDefault { get; }
        public IReadOnlyCollection<PokemonAbility> Abilities { get; }
        public IReadOnlyCollection<PokemonType> Types { get; }
        public IReadOnlyCollection<PokemonStat> Stats { get; }
        public IReadOnlyCollection<PokemonMove> Moves { get; }
        public string? SpriteFrontDefault { get; }

        public PokemonEntity(
            int id,
            string name,
            int baseExperience,
            int height,
            int weight,
            bool isDefault,
            IEnumerable<PokemonAbility> abilities,
            IEnumerable<PokemonType> types,
            IEnumerable<PokemonStat> stats,
            IEnumerable<PokemonMove> moves,
            string? spriteFrontDefault)
        {
            Id = id;
            Name = name;
            BaseExperience = baseExperience;
            Height = height;
            Weight = weight;
            IsDefault = isDefault;
            Abilities = abilities.ToList().AsReadOnly();
            Types = types.ToList().AsReadOnly();
            Stats = stats.ToList().AsReadOnly();
            Moves = moves.ToList().AsReadOnly();
            SpriteFrontDefault = spriteFrontDefault;
        }
    }
}
