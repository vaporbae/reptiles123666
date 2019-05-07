namespace ReptoRepto.Application.Category.Commands.UpdateCategory
{
    using FluentValidation;
    using ReptoRepto.Persistence;
    using System;

    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator(ReptoReptoDbContext context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
        }
    }
}
