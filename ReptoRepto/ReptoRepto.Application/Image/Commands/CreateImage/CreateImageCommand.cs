namespace ReptoRepto.Application.Image.Commands.CreateImage
{
    using FluentValidation;
    using MediatR;
    using ReptoRepto.Persistence;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateImageCommand : IRequest
    {
        public string Url { get; set; }

        public class Handler : IRequestHandler<CreateImageCommand, Unit>
        {
            private readonly ReptoReptoDbContext _context;

            public Handler(ReptoReptoDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(CreateImageCommand request, CancellationToken cancellationToken)
            {

                var vResult = await new CreateImageCommandValidator(_context).ValidateAsync(request, cancellationToken);

                if (!vResult.IsValid)
                {
                    throw new ValidationException(vResult.Errors);
                }

                var entityImage = new Domain.Entities.Image
                {
                    Url = request.Url
                };
                _context.Images.Add(entityImage);

                await _context.SaveChangesAsync(cancellationToken);

                return await Unit.Task;
            }
        }
    }
}
