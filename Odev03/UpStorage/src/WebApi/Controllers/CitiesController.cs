using Application.Features.Cities.Commands.Add;
using Application.Features.Cities.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{

    public class CitiesController : ApiControllerBase
    {

        [HttpPost]
        [ValidationFilter]
        public async Task<IActionResult> AddAsync(CityAndCommand command)
        {
           
            return Ok(await Mediator.Send(command));
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync(CityGelALLQueries queries)
        {
            return Ok(await Mediator.Send(queries));
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllAsync(int id)
        {
            return Ok(await Mediator.Send(new CityGelALLQueries(id,null)));
        }
    }
}
