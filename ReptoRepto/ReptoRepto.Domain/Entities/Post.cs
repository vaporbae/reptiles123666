using System.Collections.Generic;
using ReptoRepto.Domain.Entities.Base;

namespace SmartSchedule.Domain.Entities
{
    public class Post : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }

        ICollection<Image> Images { get; set; }
        ICollection<Comment> Comments { get; set; }
    }
}
