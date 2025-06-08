using Pokemon.Application.MestrePokemon.Requests;
using Pokemon.Application.MestrePokemon.Results;
using Pokemon.Domain.Contracts.Repositories;

namespace Pokemon.Application.MestrePokemon.UseCases
{
    public class AddMestrePokemonUseCase
    {
        private readonly IGenericRepository<Domain.Entities.MestrePokemon> _repository;

        public AddMestrePokemonUseCase(IGenericRepository<Domain.Entities.MestrePokemon> repository)
        {
            _repository = repository;
        }

        public async Task<MestrePokemonResult> ExecuteAsync(AddMestrePokemonRequest request)
        {
            var entity = new Domain.Entities.MestrePokemon
            {
                Id = Guid.NewGuid(),
                Nome = request.Nome,
                Idade = request.Idade,
                Cpf = request.Cpf
            };

            await _repository.AddAsync(entity);

            return new MestrePokemonResult
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Idade = entity.Idade,
                Cpf = entity.Cpf
            };
        }
    }
}
