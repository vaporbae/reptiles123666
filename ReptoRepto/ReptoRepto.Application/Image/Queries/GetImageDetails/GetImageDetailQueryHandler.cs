namespace ReptoRepto.Application.Image.Queries.GetImageDetails
{
    using MediatR;
    using ReptoRepto.Application.Exceptions;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetImageDetailQueryHandler : IRequestHandler<GetImageDetailQuery, ImageDetailModel>
    {
        private readonly ReptoReptoDbContext _context;

        public GetImageDetailQueryHandler(ReptoReptoDbContext context)
        {
            _context = context;
        }
        public async Task<ImageDetailModel> Handle(GetImageDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Images.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Domain.Entities.Image), request.Id);
            }

            var result = ImageDetailModel.Create(entity);

            return result;
        }
    }
}
