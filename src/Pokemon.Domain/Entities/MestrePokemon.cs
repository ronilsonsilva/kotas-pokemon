namespace Pokemon.Domain.Entities
{
    public class MestrePokemon : EntityBase
    {
        public MestrePokemon()
        {
        }

        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cpf { get; set; } = string.Empty;
    }
}
