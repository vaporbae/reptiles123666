using System;

namespace ReptoRepto.Application.Models
{
    public class JwtTokenModel
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
