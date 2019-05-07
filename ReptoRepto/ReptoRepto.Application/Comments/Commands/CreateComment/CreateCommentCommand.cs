namespace ReptoRepto.Application.Comment.Commands.CreateComment
{
    using FluentValidation;
    using MediatR;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCommentCommand : IRequest
    {
        public string Title { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

        public class Handler : IRequestHandler<CreateCommentCommand, Unit>
        {
            private readonly ReptoReptoDbContext _context;

            public Handler(ReptoReptoDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {

                var vResult = await new CreateCommentCommandValidator(_context).ValidateAsync(request, cancellationToken);

                if (!vResult.IsValid)
                {
                    throw new ValidationException(vResult.Errors);
                }

                var entityComment = new Domain.Entities.Comment
                {
                    Title = request.Title,
                    User = request.User,
                    Content = request.Content,
                    PostId = request.PostId
                };
                _context.Comments.Add(entityComment);

                await _context.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
