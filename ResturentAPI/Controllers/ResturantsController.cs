using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ResturentAPI.Handlers;
using ResturentAPI.Models;
using ResturentAPI.Repositories.Resturant;
using System.Threading.Tasks;

namespace ResturentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantsController : ControllerBase
    {
        private readonly IResturantRepository resturantRepository;
        private readonly IMediator mediator;

        public ResturantsController(IResturantRepository resturantRepository, IMediator mediator)
        {
            this.resturantRepository = resturantRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResturants()
        {
            /*var resturants = await resturantRepository.GetAllResturants();*/

            var resturants = await mediator.Send(new GetAllResturants.Query());
            return Ok(resturants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResturantById([FromRoute] int id)
        {
            //var resturant = await resturantRepository.GetResturantById(id);

            var resturant = await mediator.Send(new GetResturantById.Query() { Id = id});


            if (resturant == null)
            {
                return NotFound();
            }

            return Ok(resturant);
        }

        [HttpPost]
        public async Task<IActionResult> AddResturant([FromBody] AddResturant.Command command)
        {
            //var id = await resturantRepository.AddResturant(resturantmodel);

            var id = await mediator.Send(command);


            return CreatedAtAction(nameof(GetResturantById), new { id = id, controller = "resturants" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateResturant([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            //await resturantRepository.UpdateResturant(id, document);

            await mediator.Send(new UpdateResturant.Command() { Id = id, document = document });
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant(int id)
        {
            //await resturantRepository.DeleteResturant(id);

            await mediator.Send(new DeleteResturant.Command() { Id = id });

            return NoContent();
        }
    }
}
