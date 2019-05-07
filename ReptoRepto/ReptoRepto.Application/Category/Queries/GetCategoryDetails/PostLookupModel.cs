namespace ReptoRepto.Application.Category.Queries.GetCategoryDetails
{
    public class PostLookupModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
    }
}
