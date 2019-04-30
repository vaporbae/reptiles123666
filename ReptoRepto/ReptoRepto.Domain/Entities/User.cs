using ReptoRepto.Domain.Entities.Base;

namespace ReptoRepto.Domain.Entities
{
    public class User : BaseEntity<int>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
