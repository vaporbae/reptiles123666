namespace ReptoRepto.Application.Category.Commands.CreateCategory
{
    using FluentValidation;
    using MediatR;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateCategoryCommand : IRequest
    {
        public string Title { get; set; }

        public class Handler : IRequestHandler<CreateCategoryCommand, Unit>
        {
            private readonly ReptoReptoDbContext _context;

            public Handler(ReptoReptoDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {

                var vResult = await new CreateCategoryCommandValidator(_context).ValidateAsync(request, cancellationToken);

                if (!vResult.IsValid)
                {
                    throw new ValidationException(vResult.Errors);
                }

                var entityCategory = new Domain.Entities.Category
                {
                    Title = request.Title
                };
                _context.Categories.Add(entityCategory);

                await _context.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
