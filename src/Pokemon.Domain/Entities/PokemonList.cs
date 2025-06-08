namespace Pokemon.Domain.Entities
{
    public class PokemonList
    {
        public int Count { get; }
        public string? Next { get; }
        public string? Previous { get; }
        public IReadOnlyCollection<PokemonListItem> Results { get; }

        public PokemonList(int count, string? next, string? previous, IEnumerable<PokemonListItem> results)
        {
            Count = count;
            Next = next;
            Previous = previous;
            Results = results.ToList().AsReadOnly();
        }
    }
}
