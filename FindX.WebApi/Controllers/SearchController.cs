using AutoMapper;
using FindX.WebApi.DTOs;
using FindX.WebApi.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace FindX.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class SearchController : ControllerBase
    {
        private readonly ISearch _searchRepository;
        private readonly IMapper _mapper;

        public SearchController(ISearch searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }






        [HttpGet]
        [Route("/{query}")]
        public async Task<ActionResult<IEnumerable<ItemReadDTO>>> SearchFor(string query)
        {
            var searchResult = await _searchRepository.SearchFinderAsync(query);
            var searchResultDto = _mapper.Map<IEnumerable<ItemReadDTO>>(searchResult);
            return Ok(searchResultDto);

        }
    }
}
