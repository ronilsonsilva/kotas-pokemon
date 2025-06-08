using Pokemon.Domain.Contracts.Repositories;

namespace Pokemon.Application.MestrePokemon.UseCases
{
    public class DeleteMestrePokemonUseCase
    {
        private readonly IGenericRepository<Domain.Entities.MestrePokemon> _repository;

        public DeleteMestrePokemonUseCase(IGenericRepository<Domain.Entities.MestrePokemon> repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExecuteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
