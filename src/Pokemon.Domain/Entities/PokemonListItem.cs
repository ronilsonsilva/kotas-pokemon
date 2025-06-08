namespace Pokemon.Domain.Entities
{
    public class PokemonListItem
    {
        public string Name { get; }
        public string Url { get; }

        public PokemonListItem(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
