using System.Collections.Generic;
using ReptoRepto.Domain.Entities.Base;

namespace ReptoRepto.Domain.Entities
{
    public class Image : BaseEntity<int>
    {
        public string Url { get; set; }
    }
}
