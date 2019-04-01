using System.Collections.Generic;
using ReptoRepto.Domain.Entities.Base;

namespace SmartSchedule.Domain.Entities
{
    public class Comment : BaseEntity<int>
    {
        public string Title { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
