namespace ReptoRepto.Application.Image.Queries.GetImageDetails
{
    using System;
    using System.Linq.Expressions;

    public class ImageDetailModel
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public static Expression<Func<Domain.Entities.Image, ImageDetailModel>> Projection
        {
            get
            {
                return image => new ImageDetailModel
                {
                    Id = image.Id,
                    Url = image.Url
                };
            }
        }

        public static ImageDetailModel Create(Domain.Entities.Image image)
        {
            return Projection.Compile().Invoke(image);
        }
    }
}
