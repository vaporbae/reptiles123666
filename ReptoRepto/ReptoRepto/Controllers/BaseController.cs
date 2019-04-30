﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ReptoRepto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}

