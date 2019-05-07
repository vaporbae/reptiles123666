namespace ReptoRepto.Application.Category.Commands.DeleteCategory
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Application.Exceptions;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteCategoryCommand, Unit>
        {
            private readonly ReptoReptoDbContext _context;

            public Handler(ReptoReptoDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

                if (category == null)
                {
                    throw new NotFoundException("Category", request.Id);
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
