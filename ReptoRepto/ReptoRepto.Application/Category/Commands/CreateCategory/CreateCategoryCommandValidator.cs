namespace ReptoRepto.Application.Category.Commands.CreateCategory
{
    using FluentValidation;
    using ReptoRepto.Persistence;
    using System;

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator(ReptoReptoDbContext context)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
        }
    }
}
