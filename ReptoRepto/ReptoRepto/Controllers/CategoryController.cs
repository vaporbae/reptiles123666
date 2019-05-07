namespace ReptoRepto.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReptoRepto.Application.Category.Commands.CreateCategory;
    using ReptoRepto.Application.Category.Commands.DeleteCategory;
    using ReptoRepto.Application.Category.Commands.UpdateCategory;
    using ReptoRepto.Application.Category.Queries.GetCategoryDetails;
    using ReptoRepto.Application.Category.Queries.GetCategoryList;
    using System.Threading.Tasks;

    public class CategoryController : BaseController
    {
        [HttpPost("/api/CreateCategory")]
        public async Task<IActionResult> CreateImage([FromBody]CreateCategoryCommand category)
        {
            return Ok(await Mediator.Send(category));
        }

        [HttpPost("/api/DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromBody]DeleteCategoryCommand category)
        {
            return Ok(await Mediator.Send(category));
        }

        [HttpPost("/api/UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryCommand category)
        {
            return Ok(await Mediator.Send(category));
        }

        [HttpGet("/api/categories")]
        public async Task<IActionResult> GetCategoriesList()
        {
            return Ok(await Mediator.Send(new GetCategoryListQuery()));
        }

        [HttpGet("/api/category/details/{id}")]
        public async Task<IActionResult> GetCategoryDetails(int id)
        {
            var query = new GetCategoryDetailQuery
            {
                Id = id
            };

            return Ok(await Mediator.Send(query));
        }
    }
}
