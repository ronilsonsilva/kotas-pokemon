namespace Pokemon.Domain.Entities
{
    public class PokemonAbility
    {
        public string Name { get; }
        public bool IsHidden { get; }
        public int Slot { get; }

        public PokemonAbility(string name, bool isHidden, int slot)
        {
            Name = name;
            IsHidden = isHidden;
            Slot = slot;
        }
    }
}
