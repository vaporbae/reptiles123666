namespace ReptoRepto.Application.Category.Queries.GetCategoryDetails
{
    using MediatR;
    using ReptoRepto.Application.Exceptions;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCategoryDetailQueryHandler : IRequestHandler<GetCategoryDetailQuery, CategoryDetailModel>
    {
        private readonly ReptoReptoDbContext _context;

        public GetCategoryDetailQueryHandler(ReptoReptoDbContext context)
        {
            _context = context;
        }
        public async Task<CategoryDetailModel> Handle(GetCategoryDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);
            }

            var result = CategoryDetailModel.Create(entity);

            return result;
        }
    }
}
