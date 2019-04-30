namespace ReptoRepto.Application.Image.Commands.CreateImage
{
    using FluentValidation;
    using ReptoRepto.Persistence;
    using System;

    public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand>
    {
        public CreateImageCommandValidator(ReptoReptoDbContext context)
        {
            RuleFor(x => x.Url).NotEmpty().MustAsync(async (request, val, token) =>
            {
                Uri uriResult;
                bool result = Uri.TryCreate(val, UriKind.Absolute, out uriResult)
                    && uriResult.Scheme == Uri.UriSchemeHttp;

                return result;
            }).WithMessage("This URL is not correct.");
        }
    }
}
