using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyToday.Application.Dtos;
using PropertyToday.Application.Features.Images.Commands;
using PropertyToday.Application.Features.Images.Queries;

namespace PropertyTodayWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ISender _Sender;
        public ImagesController(ISender sender)
        {
            _Sender = sender;
        }

        [HttpPost("AddImage")]
        public async Task<ActionResult> AddImage([FromBody] NewImage image)
        {
             bool response = await _Sender.Send(new CreateImageCommand(image));
            if (response)
            {
                return Ok("New Image successfully added!");
            }
            return BadRequest("Image failed to be added!");
        }

        [HttpPut("UpdateImage")]
        public async Task<ActionResult> UpdateImage([FromBody] UpdateImageRequest image)
        {
             bool response = await _Sender.Send(new UpdateImageCommand(image)); 
            if (response)
            {
                return Ok("Image successfully updated!");
            }
            return BadRequest("Image failed to be updated!");
        }

         [HttpDelete("DeleteImage/{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
             bool response = await _Sender.Send(new DeleteImageCommand(id)); 
            if (response)
            {
                return Ok("Image successfully deleted!"); 
            }
            return BadRequest("Image failed to be deleted!");
        }

        [HttpGet("GetAllImages")]
        public async Task<ActionResult> GetAllImages()
        {
             var model = await _Sender.Send(new GetImagesQuery()); 
            if (model != null)
            {
                return Ok(model); 
            }
            return NotFound("Images are not found");
        }

        
        [HttpGet("GetImage/{id}")]
        public async Task<ActionResult> GetImage(int id)
        {
             var model = await _Sender.Send(new GetImageByIdQuery(id)); 
            if (model != null)
            {
                return Ok(model); 
            }
            return NotFound("Image not found");
        }



    }
}
