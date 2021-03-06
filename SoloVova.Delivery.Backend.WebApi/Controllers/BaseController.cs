using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SoloVova.Delivery.Backend.WebApi.Controllers{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase{
        private IMediator? _mediator;
        private IConfiguration? _configuration;

        protected IConfiguration Configuration{
            get{
                _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
                if (this._configuration == null){
                    throw new Exception("Configuration is null");
                }

                return this._configuration;
            }
        }

        protected IMediator Mediator{
            get{
                _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
                if (this._mediator == null){
                    throw new Exception("Mediator is null");
                }

                return this._mediator;
            }
        }


        //
        // internal Guid UserId{
        //     get{
        //         if (User?.Identity == null || !User.Identity.IsAuthenticated){
        //             return Guid.Empty;
        //         }
        //
        //         Claim? user = User.FindFirst(ClaimTypes.NameIdentifier);
        //         return user != null ? Guid.Parse(user.Value) : Guid.Empty;
        //     }
        // }
    }
}