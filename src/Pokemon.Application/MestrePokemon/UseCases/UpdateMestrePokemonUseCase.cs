using Pokemon.Application.MestrePokemon.Requests;
using Pokemon.Application.MestrePokemon.Results;
using Pokemon.Domain.Contracts.Repositories;

namespace Pokemon.Application.MestrePokemon.UseCases
{
    public class UpdateMestrePokemonUseCase
    {
        private readonly IGenericRepository<Domain.Entities.MestrePokemon> _repository;

        public UpdateMestrePokemonUseCase(IGenericRepository<Domain.Entities.MestrePokemon> repository)
        {
            _repository = repository;
        }

        public async Task<MestrePokemonResult?> ExecuteAsync(UpdateMestrePokemonRequest request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return null;

            entity.Nome = request.Nome;
            entity.Idade = request.Idade;
            entity.Cpf = request.Cpf;

            await _repository.UpdateAsync(entity);

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
