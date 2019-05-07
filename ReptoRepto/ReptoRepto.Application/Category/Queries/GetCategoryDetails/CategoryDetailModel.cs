namespace ReptoRepto.Application.Category.Queries.GetCategoryDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class CategoryDetailModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<PostLookupModel> Posts { get; set; }

        public static Expression<Func<Domain.Entities.Category, CategoryDetailModel>> Projection
        {
            get
            {
                return category => new CategoryDetailModel
                {
                    Id = category.Id,
                    Title = category.Title,
                    Posts = category.Posts.Select(y => new PostLookupModel
                    {
                        Id = y.Id,
                        Title = y.Title,
                        Author = y.Author,
                        Content = y.Content
                    }).ToList()
                };
            }
        }

        public static CategoryDetailModel Create(Domain.Entities.Category category)
        {
            return Projection.Compile().Invoke(category);
        }
    }
}
