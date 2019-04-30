namespace ReptoRepto.Application.Image.Commands.DeleteImage
{
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using ReptoRepto.Application.Exceptions;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteImageCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteImageCommand, Unit>
        {
            private readonly ReptoReptoDbContext _context;

            public Handler(ReptoReptoDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
            {
                var image = await _context.Images.FirstOrDefaultAsync(x => x.Id.Equals(request.Id));

                if (image == null)
                {
                    throw new NotFoundException("Image", request.Id);
                }

                _context.Images.Remove(image);
                await _context.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
