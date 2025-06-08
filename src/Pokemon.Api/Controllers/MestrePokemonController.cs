using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.MestrePokemon.Requests;
using Pokemon.Application.MestrePokemon.Results;
using Pokemon.Application.MestrePokemon.UseCases;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MestrePokemonController : ControllerBase
    {
        private readonly AddMestrePokemonUseCase _addUseCase;
        private readonly UpdateMestrePokemonUseCase _updateUseCase;
        private readonly DeleteMestrePokemonUseCase _deleteUseCase;
        private readonly GetMestrePokemonByIdUseCase _getByIdUseCase;
        private readonly GetMestrePokemonsPagedUseCase _getPagedUseCase;

        public MestrePokemonController(
            AddMestrePokemonUseCase addUseCase,
            UpdateMestrePokemonUseCase updateUseCase,
            DeleteMestrePokemonUseCase deleteUseCase,
            GetMestrePokemonByIdUseCase getByIdUseCase,
            GetMestrePokemonsPagedUseCase getPagedUseCase)
        {
            _addUseCase = addUseCase;
            _updateUseCase = updateUseCase;
            _deleteUseCase = deleteUseCase;
            _getByIdUseCase = getByIdUseCase;
            _getPagedUseCase = getPagedUseCase;
        }

        /// <summary>
        /// Adiciona um novo mestre pokémon.
        /// </summary>
        /// <param name="request">Dados do mestre pokémon.</param>
        /// <returns>Dados do mestre pokémon criado.</returns>
        /// <response code="201">Mestre pokémon criado com sucesso.</response>
        [HttpPost]
        [ProducesResponseType(typeof(MestrePokemonResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] AddMestrePokemonRequest request)
        {
            var result = await _addUseCase.ExecuteAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Atualiza um mestre pokémon existente.
        /// </summary>
        /// <param name="request">Dados do mestre pokémon.</param>
        /// <returns>Dados do mestre pokémon atualizado.</returns>
        /// <response code="200">Mestre pokémon atualizado com sucesso.</response>
        /// <response code="404">Mestre pokémon não encontrado.</response>
        [HttpPut]
        [ProducesResponseType(typeof(MestrePokemonResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateMestrePokemonRequest request)
        {
            var result = await _updateUseCase.ExecuteAsync(request);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Remove um mestre pokémon pelo id.
        /// </summary>
        /// <param name="id">Id do mestre pokémon.</param>
        /// <response code="204">Mestre pokémon removido com sucesso.</response>
        /// <response code="404">Mestre pokémon não encontrado.</response>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _deleteUseCase.ExecuteAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Obtém um mestre pokémon pelo id.
        /// </summary>
        /// <param name="id">Id do mestre pokémon.</param>
        /// <returns>Dados do mestre pokémon.</returns>
        /// <response code="200">Mestre pokémon encontrado.</response>
        /// <response code="404">Mestre pokémon não encontrado.</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(MestrePokemonResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _getByIdUseCase.ExecuteAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Lista todos os mestres pokémon paginados.
        /// </summary>
        /// <param name="page">Número da página.</param>
        /// <param name="pageSize">Tamanho da página.</param>
        /// <returns>Lista paginada de mestres pokémon.</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MestrePokemonResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaged([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
        {
            var result = await _getPagedUseCase.ExecuteAsync(page, pageSize);
            return Ok(result);
        }
    }
}
