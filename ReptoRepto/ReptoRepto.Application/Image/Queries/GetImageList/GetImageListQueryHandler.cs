namespace ReptoRepto.Application.Image.Queries.GetImageList
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetImageListQueryHandler : IRequestHandler<GetImageListQuery, ImageListViewModel>
    {
        private readonly ReptoReptoDbContext _context;
        private readonly IMapper _mapper;

        public GetImageListQueryHandler(ReptoReptoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ImageListViewModel> Handle(GetImageListQuery request, CancellationToken cancellationToken)
        {
            return new ImageListViewModel
            {
                Images = await _context.Images.ProjectTo<ImageLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
