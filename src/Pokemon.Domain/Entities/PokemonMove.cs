namespace Pokemon.Domain.Entities
{
    public class PokemonMove
    {
        public string Name { get; }

        public PokemonMove(string name)
        {
            Name = name;
        }
    }
}
