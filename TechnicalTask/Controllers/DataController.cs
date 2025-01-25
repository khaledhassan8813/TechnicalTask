using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace TechnicalTask.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("person-data")]
        public async Task<IActionResult> GetUnifiedData([FromQuery] string? name = null,
                                                 [FromQuery] string? phone = null,
                                                 [FromQuery] string? country = null)
        {
            var unifiedData = await _dataService.GetUnifiedDataAsync(name, phone, country);
            return Ok(unifiedData);
        }
    }
}
