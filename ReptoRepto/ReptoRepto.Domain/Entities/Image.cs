using System.Collections.Generic;
using ReptoRepto.Domain.Entities.Base;

namespace SmartSchedule.Domain.Entities
{
    public class Image : BaseEntity<int>
    {
        public string Url { get; set; }
        public int PostId { get; set; }
        
        public Post Post { get; set; }
    }
}
