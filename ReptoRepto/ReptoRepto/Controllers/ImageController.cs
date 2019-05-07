namespace ReptoRepto.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReptoRepto.Application.Image.Commands.CreateImage;
    using ReptoRepto.Application.Image.Commands.DeleteImage;
    using ReptoRepto.Application.Image.Queries.GetImageDetails;
    using ReptoRepto.Application.Image.Queries.GetImageList;
    using System.Threading.Tasks;

    public class ImageController : BaseController
    {
        [HttpPost("/api/CreateImage")]
        public async Task<IActionResult> CreateImage([FromBody]CreateImageCommand image)
        {
            return Ok(await Mediator.Send(image));
        }

        [HttpPost("/api/DeleteImage")]
        public async Task<IActionResult> DeleteImage([FromBody]DeleteImageCommand image)
        {
            return Ok(await Mediator.Send(image));
        }

        [HttpGet("/api/images")]
        public async Task<IActionResult> GetImagesList()
        {
            return Ok(await Mediator.Send(new GetImageListQuery()));
        }

        [HttpGet("/api/image/details/{id}")]
        public async Task<IActionResult> GetImageDetails(int id)
        {
            var query = new GetImageDetailQuery
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
