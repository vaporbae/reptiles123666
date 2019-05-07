namespace ReptoRepto.Application.Category.Queries.GetCategoryList
{
    using AutoMapper;
    using ReptoRepto.Application.Interfaces.Mapping;

    public class CategoryLookupModel : IHaveCustomMapping
    {
        public int Id { get; set; }
        public int Title { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Domain.Entities.Category, CategoryLookupModel>()
                .ForMember(cDTO => cDTO.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(cDTO => cDTO.Title, opt => opt.MapFrom(c => c.Title));
        }
    }
}
