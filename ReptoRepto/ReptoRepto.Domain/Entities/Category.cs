using System.Collections.Generic;
using ReptoRepto.Domain.Entities.Base;

namespace ReptoRepto.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
