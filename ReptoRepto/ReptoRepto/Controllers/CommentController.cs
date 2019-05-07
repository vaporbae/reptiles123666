namespace ReptoRepto.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReptoRepto.Application.Comment.Commands.CreateComment;
    using ReptoRepto.Application.Comment.Commands.DeleteComment;
    using ReptoRepto.Application.Comments.Queries.SearchUserComments;
    using System.Threading.Tasks;

    public class CommentController : BaseController
    {
        [HttpPost("/api/CreateComment")]
        public async Task<IActionResult> CreateComment([FromBody]CreateCommentCommand comment)
        {
            return Ok(await Mediator.Send(comment));
        }

        [HttpPost("/api/DeleteComment")]
        public async Task<IActionResult> DeleteComment([FromBody]DeleteCommentCommand comment)
        {
            return Ok(await Mediator.Send(comment));
        }

        [HttpGet("/api/search/UserCommenents")]
        public async Task<IActionResult> SearchUserComments()
        {
            return Ok(await Mediator.Send(new SearchUserCommentsQuery()));
        }
    }
}
