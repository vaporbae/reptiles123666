namespace ReptoRepto.Application.Comment.Commands.CreateComment
{
    using FluentValidation;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Persistence;

    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator(ReptoReptoDbContext context)
        {
            RuleFor(x => x.PostId).NotEmpty().MustAsync(async (request, val, token) =>
            {
                var postResult = await context.Posts.FirstOrDefaultAsync(x => x.Id.Equals(val));

                if (postResult == null)
                {
                    return false;
                }

                return true;
            }).WithMessage("This post does not exist.");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
            RuleFor(x => x.User).NotEmpty().WithMessage("Author cannot be empty.");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content cannot be empty.");
        }
    }
}
