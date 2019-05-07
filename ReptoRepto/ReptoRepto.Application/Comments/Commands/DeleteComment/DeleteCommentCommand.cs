namespace ReptoRepto.Application.Comment.Commands.DeleteComment
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Application.Exceptions;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteCommentCommand, Unit>
        {
            private readonly ReptoReptoDbContext _context;

            public Handler(ReptoReptoDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

                if (comment == null)
                {
                    throw new NotFoundException("Comment", request.Id);
                }

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
