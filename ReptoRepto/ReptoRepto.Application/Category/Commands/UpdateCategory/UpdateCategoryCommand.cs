namespace ReptoRepto.Application.Category.Commands.UpdateCategory
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Application.Exceptions;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public class Handler : IRequestHandler<UpdateCategoryCommand, Unit>
        {
            private readonly ReptoReptoDbContext _context;

            public Handler(ReptoReptoDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

                if (category == null)
                {
                    throw new NotFoundException("Category", request.Id);
                }

                var vResult = await new UpdateCategoryCommandValidator(_context).ValidateAsync(request, cancellationToken);

                if (!vResult.IsValid)
                {
                    throw new FluentValidation.ValidationException(vResult.Errors);
                }

                category.Title = request.Title;
                _context.Categories.Update(category);

                await _context.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
