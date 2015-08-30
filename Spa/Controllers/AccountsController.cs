using System;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Spa.Dtos;
using Spa.Infrastructure;

namespace Spa.Controllers
{
    public class AccountsController : BaseApiController
    {
        [Authorize]
        public async Task<IHttpActionResult> GetByUserId(int userId)
        {
            var response = await AppUserManager.FindByIdAsync(userId);

            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [Authorize]
        public async Task<IHttpActionResult> GetByUserName(string userName)
        {
            var response = await AppUserManager.FindByNameAsync(userName);

            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateUser(User customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            IdentityResult addUserResult = await AppUserManager.CreateAsync(customer, customer.PasswordHash);

            if (!addUserResult.Succeeded)
            {
                if (addUserResult.Errors != null)
                {
                    foreach (string error in addUserResult.Errors)
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

            //Rest of code is removed for brevity
            string code = await AppUserManager.GenerateEmailConfirmationTokenAsync(customer.Id);
            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = customer.Id, password = customer.PasswordHash, code = code }));
            await AppUserManager.SendEmailAsync(customer.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            Uri locationHeader = new Uri(Url.Link("GetByUserId", new {id = customer.Id}));

            return Created(locationHeader, customer);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(int userId, string password, string code = "")
        {
            if (userId != 0 || string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "User Id, Password and Code are required");
                return BadRequest(ModelState);
            }

            User user = await AppUserManager.FindByIdAsync(userId);
            bool isPasswordRight = await AppUserManager.CheckPasswordAsync(user, password);

            if (!isPasswordRight)
            {
                ModelState.AddModelError("", "Password is wrong");
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok();
            }

            return GetErrorResult(result);
        }

        [Authorize]
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(NewPasswordDto newPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.ChangePasswordAsync(User.Identity.GetUserId<int>(), newPassword.OldPassword, newPassword.NewPassword);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
    }
}