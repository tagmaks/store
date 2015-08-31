using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using Microsoft.AspNet.Identity.Owin;
using Spa.Dtos;
using Spa.Infrastructure;

namespace Spa.Controllers
{
    public class UsersController : ODataController
    {

        private readonly AppUserManager _appUserManager;
        private readonly ISpaRepository<User, UserDto, UserDtoAsync> _repo;

        public UsersController(ISpaRepository<User, UserDto, UserDtoAsync> repo)
        {
            _repo = repo;
            _appUserManager = Request.GetOwinContext().GetUserManager<AppUserManager>();
        }

        [EnableQuery(PageSize = 10)]
        public IHttpActionResult Get()
        {
            var response = _repo.GetAllDto();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }

        [EnableQuery]
        public IHttpActionResult Get([FromODataUri] int key)
        {
            var response = _repo.GetDto(key);
            if (response.IsValid)
            {
                return Ok(response.Result);
            }
            return NotFound();
        }

        //public async Task<IHttpActionResult> Post(UserDto customer)
        //{
        //    if (!ModelState. IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    IdentityResult addUseResult = await _appUserManager.CreateAsync(customer, customer.PasswordHash);

        //    if (!addUseResult.Succeeded)
        //    {
        //        return GetErrorResult(addUserResult);
        //    }

        //    return Created(ModelState);
        //}

        //public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<User> patch)
        //{
        //    //Check if properties name are valid
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (patch == null)
        //    {
        //        return BadRequest();
        //    }

        //    var entity = await _repo.GetAsync(key);
        //    var customer = entity.Result;
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(customer);

        //    var response = await _repo.PatchAsync(customer);
        //    if (response.IsValid)
        //    {
        //        return Updated(customer);
        //    }
        //    response.CopyErrorsToModelState(ModelState);
        //    return BadRequest(ModelState);
        //}

        //public async Task<IHttpActionResult> Put([FromODataUri] int key, User update)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (key != update.Id)
        //    {
        //        return BadRequest();
        //    }

        //    var response = await _repo.PatchAsync(update);
        //    if (response.IsValid)
        //    {
        //        return Updated(update);
        //    }
        //    response.CopyErrorsToModelState(ModelState);
        //    return BadRequest(ModelState);
        //}

        //public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        //{
        //    //var customer = await _repo.GetAsync(key);
        //    //if (customer == null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    var response = await _repo.DeleteAsync(key);
        //    if (response.IsValid)
        //    {
        //        return Ok();
        //    }
        //    response.CopyErrorsToModelState(ModelState);
        //    return BadRequest(ModelState);
        //}
    }
}