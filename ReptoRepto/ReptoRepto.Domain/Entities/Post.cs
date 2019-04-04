using System.Collections.Generic;
using ReptoRepto.Domain.Entities.Base;

namespace ReptoRepto.Domain.Entities
{
    public class Post : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Source> Sources { get; set; }
    }
}
