namespace Pokemon.Application.MestrePokemon.Requests
{
    public class UpdateMestrePokemonRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cpf { get; set; } = string.Empty;
    }
}
