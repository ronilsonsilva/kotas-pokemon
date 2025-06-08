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
        /// Retorna uma lista paginada de pokémons.
        /// </summary>
        /// <param name="offset">O deslocamento do primeiro item a ser retornado.</param>
        /// <param name="limit">A quantidade máxima de itens a ser retornada.</param>
        /// <returns>Lista paginada de pokémons.</returns>
        /// <response code="200">Retorna a lista de pokémons.</response>
        [HttpGet]
        [ProducesResponseType(typeof(PokemonListResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetList()
        {
            var result = await _getPokemonListUseCase.ExecuteAsync();
            return Ok(result);
        }

        /// <summary>
        /// Retorna os detalhes de um pokémon específico pelo nome.
        /// </summary>
        /// <param name="name">O nome do pokémon.</param>
        /// <returns>Detalhes do pokémon.</returns>
        /// <response code="200">Retorna os detalhes do pokémon.</response>
        /// <response code="404">Se o pokémon não for encontrado.</response>
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
