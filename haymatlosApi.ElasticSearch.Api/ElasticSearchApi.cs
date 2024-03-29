using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace haymatlosApi.haymatlosApi.ElasticSearch.Api
{
    [Route("/ElasticSearch")]
    [AllowAnonymous]
    [ApiController]
    public class ElasticSearchApi : ControllerBase
    {
        readonly ElasticService _elasticService;
        public ElasticSearchApi(ElasticService elastic) {
            _elasticService = elastic;
        } 

        [HttpGet("fullTextSearch")]
        [Authorize(Roles = "user")]
        public async Task<IReadOnlyCollection<Document>> fullTextSearch(string searchQuery)
        {
            return await _elasticService.fullTextSearch("users",searchQuery);
        }
    }
}
