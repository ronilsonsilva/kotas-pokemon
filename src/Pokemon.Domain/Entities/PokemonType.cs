namespace Pokemon.Domain.Entities
{
    public class PokemonType
    {
        public string Name { get; }
        public int Slot { get; }

        public PokemonType(string name, int slot)
        {
            Name = name;
            Slot = slot;
        }
    }
}
