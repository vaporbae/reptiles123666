﻿namespace ReptoRepto.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ReptoRepto.Application.Interfaces;
    using ReptoRepto.Application.Models;
    public class LoginController : BaseController
    {
        private readonly IJwtService _jwt;
        public LoginController(IJwtService jwt)
        {
            _jwt = jwt;
        }
        [HttpPost("/api/login")]
        public async Task<IActionResult> Login([FromBody]LoginSignInModel model)
        {
            return await _jwt.Login(model);
        }
    }
}
