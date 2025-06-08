namespace Pokemon.Domain.Entities
{
    public class PokemonStat
    {
        public string Name { get; }
        public int BaseStat { get; }
        public int Effort { get; }

        public PokemonStat(string name, int baseStat, int effort)
        {
            Name = name;
            BaseStat = baseStat;
            Effort = effort;
        }
    }
}
