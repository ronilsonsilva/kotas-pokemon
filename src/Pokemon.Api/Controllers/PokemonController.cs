using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Results;
using Pokemon.Application.UseCases;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly GetPokemonListUseCase _getPokemonListUseCase;
        private readonly GetPokemonDetailUseCase _getPokemonDetailUseCase;

        public PokemonController(
            GetPokemonListUseCase getPokemonListUseCase,
            GetPokemonDetailUseCase getPokemonDetailUseCase)
        {
            _getPokemonListUseCase = getPokemonListUseCase;
            _getPokemonDetailUseCase = getPokemonDetailUseCase;
        }

        /// <summary>
        /// Returns a paginated list of pokémons.
        /// </summary>
        /// <param name="offset">The offset of the first item to return.</param>
        /// <param name="limit">The maximum number of items to return.</param>
        /// <returns>Paginated list of pokémons.</returns>
        /// <response code="200">Returns the list of pokémons.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PokemonListResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList([FromQuery] int offset = 0, [FromQuery] int limit = 20)
        {
            var result = await _getPokemonListUseCase.ExecuteAsync(offset, limit);
            return Ok(result);
        }

        /// <summary>
        /// Returns the details of a specific pokémon by name.
        /// </summary>
        /// <param name="name">The name of the pokémon.</param>
        /// <returns>Pokémon details.</returns>
        /// <response code="200">Returns the pokémon details.</response>
        /// <response code="404">If the pokémon is not found.</response>
        [HttpGet("{name}")]
        [ProducesResponseType(typeof(PokemonDetailResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDetail(string name)
        {
            var result = await _getPokemonDetailUseCase.ExecuteAsync(name);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
