using Application.Features.Excel.Commands.ReadCities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    
    public class ExcelController : ApiControllerBase
    {
        [HttpPost("ReadCities")]
        public async Task<IActionResult> Create(ExcelReadCitiesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
