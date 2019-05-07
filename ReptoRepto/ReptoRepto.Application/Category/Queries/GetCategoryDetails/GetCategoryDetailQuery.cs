namespace ReptoRepto.Application.Category.Queries.GetCategoryDetails
{
    using MediatR;

    public class GetCategoryDetailQuery : IRequest<CategoryDetailModel>
    {
        public int Id { get; set; }
    }
}
