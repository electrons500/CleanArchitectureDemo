using MediatR;
using Microsoft.AspNetCore.Mvc;
using PropertyToday.Application.Dtos;
using PropertyToday.Application.Features.Properties.Commands;
using PropertyToday.Application.Features.Properties.Queries;
using PropertyToday.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyTodayWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private ISender _sender;

        public PropertiesController(ISender sender)
        {
            _sender = sender;
        }

      
       
        // POST api/<PropertiesController>
        [HttpPost("AddNewProperty")]
        public async Task<ActionResult> AddNewProperty([FromBody] NewPropertyRequest request)
        {
            bool response = await _sender.Send(new CreatePropertyCommand(request));
            if(response)
            {
                return Ok("New property successfully added!");
            }

            return BadRequest("New property failed to be added!");

        }

        // POST api/<PropertiesController>
        [HttpPut("UpdateProperty")]
        public async Task<ActionResult> UpdateProperty([FromBody] UpdatePropertyRequest request) 
        {
            bool response = await _sender.Send(new UpdatePropertyCommand(request));
            if(response)
            {
                return Ok("Property successfully updated!");
            }

            return NotFound("Property not found!");

        }

         // POST api/<PropertiesController>
        [HttpGet("GetProperty/{id}")]
        public async Task<ActionResult> GetProperty(int id) 
        {
            GetPropertyQuery property = await _sender.Send(new GetPropertyByIdQuery(id));
            if(property != null )
            {
                return Ok(property);
            }

            return NotFound("Property not found!");

        }

       [HttpGet("GetAllProperties")]
        public async Task<ActionResult> GetAllProperties() 
        {
            List<GetPropertyQuery> property = await _sender.Send(new GetAllPropertiesQuery());
            if(property != null )
            {
                return Ok(property);
            }

            return NotFound("Properties not found!");

        }

        [HttpDelete("DeleteProperty/{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            bool result = await _sender.Send(new DeletePropertyCommand(id));
            if (result)
            {
                return Ok("Property successfully deleted!.");
            }

            return NotFound("Property not found!");

        }


    }
}
