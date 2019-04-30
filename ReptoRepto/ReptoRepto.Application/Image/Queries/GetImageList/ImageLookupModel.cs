namespace ReptoRepto.Application.Image.Queries.GetImageList
{
    using AutoMapper;
    using ReptoRepto.Application.Interfaces.Mapping;
    using System.Linq;

    public class ImageLookupModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public int Url { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Image, ImageLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Url, opt => opt.MapFrom(c => c.Url));
        }
    }
}
