namespace ReptoRepto.Application.Category.Queries.GetCategoryList
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, CategoryListViewModel>
    {
        private readonly ReptoReptoDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(ReptoReptoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryListViewModel> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            return new CategoryListViewModel
            {
                Categories = await _context.Categories.ProjectTo<CategoryLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
