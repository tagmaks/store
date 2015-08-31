﻿using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Spa.Infrastructure;

namespace Spa.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly AppUserManager _appUserManager;

        protected AppUserManager AppUserManager => _appUserManager ?? Request.GetOwinContext().GetUserManager<AppUserManager>();

        public BaseApiController()
        {
            //AppUserManager = Request.GetOwinContext().GetUserManager<AppUserManager>();
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
