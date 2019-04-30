namespace ReptoRepto.Application.Image.Queries.GetImageDetails
{
    using MediatR;

    public class GetImageDetailQuery : IRequest<ImageDetailModel>
    {
        public int Id { get; set; }
    }
}
