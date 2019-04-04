using System.Collections.Generic;
using ReptoRepto.Domain.Entities.Base;

namespace ReptoRepto.Domain.Entities
{
    public class Source : BaseEntity<int>
    {
        public string Content { get; set; }
        public int PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
