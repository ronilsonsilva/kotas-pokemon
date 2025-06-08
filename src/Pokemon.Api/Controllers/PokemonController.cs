using Microsoft.AspNetCore.Mvc;
using Pokemon.Application.Pokemons.Requests;
using Pokemon.Application.Pokemons.Results;
using Pokemon.Application.Pokemons.UseCases;

namespace Pokemon.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly GetPokemonListUseCase _getPokemonListUseCase;
        private readonly GetPokemonDetailUseCase _getPokemonDetailUseCase;
        private readonly CapturePokemonUseCase _capturePokemonUseCase;
        private readonly GetCapturedPokemonsPagedUseCase _getCapturedPokemonsPagedUseCase;

        public PokemonController(
            GetPokemonListUseCase getPokemonListUseCase,
            GetPokemonDetailUseCase getPokemonDetailUseCase,
            CapturePokemonUseCase capturePokemonUseCase,
            GetCapturedPokemonsPagedUseCase getCapturedPokemonsPagedUseCase)
        {
            _getPokemonListUseCase = getPokemonListUseCase;
            _getPokemonDetailUseCase = getPokemonDetailUseCase;
            _capturePokemonUseCase = capturePokemonUseCase;
            _getCapturedPokemonsPagedUseCase = getCapturedPokemonsPagedUseCase;
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
        public async Task<IActionResult> GetList()
        {
            var result = await _getPokemonListUseCase.ExecuteAsync();
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
        public async Task<IActionResult> GetById(string name)
        {
            var result = await _getPokemonDetailUseCase.ExecuteAsync(name);
            if (result == null)
                return NotFound();
            return Ok(result);
        }


        /// <summary>
        /// Captura um pokémon para um mestre.
        /// </summary>
        /// <param name="request">Dados da captura (nome do pokémon e id do mestre).</param>
        /// <returns>Dados do pokémon capturado.</returns>
        /// <response code="201">Pokémon capturado com sucesso.</response>
        /// <response code="404">Pokémon não encontrado no serviço externo.</response>
        [HttpPost("capturar")]
        [ProducesResponseType(typeof(CapturePokemonResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Capture([FromBody] CapturePokemonRequest request)
        {
            var result = await _capturePokemonUseCase.ExecuteAsync(request);
            if (result == null)
                return NotFound("Pokémon não encontrado no serviço externo.");
            return CreatedAtAction(nameof(GetById), new { name = result.Name }, result);
        }

        /// <summary>
        /// Lista os pokémons capturados na base de dados, paginado.
        /// </summary>
        /// <param name="page">Número da página.</param>
        /// <param name="pageSize">Tamanho da página.</param>
        /// <returns>Lista paginada de pokémons capturados.</returns>
        /// <response code="200">Lista retornada com sucesso.</response>
        [HttpGet("capturados")]
        [ProducesResponseType(typeof(IEnumerable<CapturedPokemonResult>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCaptured([FromQuery] int page = 0, [FromQuery] int pageSize = 10)
        {
            var result = await _getCapturedPokemonsPagedUseCase.ExecuteAsync(page, pageSize);
            return Ok(result);
        }
    }
}
