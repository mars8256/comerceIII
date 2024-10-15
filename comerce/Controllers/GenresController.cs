using AutoMapper;
using comerce.Core.Dtos.Response;
using comerce.Core.Entities;
using comerce.Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace comerce.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        public readonly IGenreService _genreService;
        public readonly IMapper _mapper;

        public GenresController(IGenreService genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get genres
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            //var mecanicos = _mecanicosService.GetMecanicos(filter);

            var genres = await _genreService.GetAll();

            var genresDto = _mapper.Map<IEnumerable<GenreResponseDto>>(genres);

            //var mecanicosDto = _mapper.Map<IEnumerable<MecanicoResponseDto>>(mecanicos);

            //var response = new AguilaResponse<IEnumerable<MecanicoResponseDto>>(mecanicosDto, mecanicos.metadata);

            return Ok(genresDto);
        }

    }
}
