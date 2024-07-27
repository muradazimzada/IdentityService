using IdentityService.Attributes;
using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using IdentityService.Dtos.RequestDtos.Authentication;
using IdentityService.Dtos.RequestDtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRoles(roles:"SuperAdmin")]
    public class UserController(IUserService userService) : ControllerBase
    {


        [HttpPost]
        public IActionResult Add(UserCreateRequest userCreateRequest)
        {

            foreach (var claim in HttpContext.User.Claims)
            {
                Console.WriteLine
                    ($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }

            //var x = HttpContext.User.FindFirstValue("UserAccessInfo");
            var userAccessInfoClaim = HttpContext.User.FindFirstValue("UserAccessInfo");
            if (userAccessInfoClaim == null)
            {
                //context.Result = new ForbidResult();
                //return;
            }

            var userAccessInfo = JsonSerializer.Deserialize<UserAccessInfo>(userAccessInfoClaim);

            return Ok (userAccessInfo);
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(userService.GetUserById(id));
        }

        //[HttpPut("{id}")]
        //public IActionResult Update(int id, UserUpdateRequest userUpdateRequest)
        //{
        //    return Ok(userService.UpdateUser(id, userUpdateRequest));
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            // find user by id

            var user = await userService.GetUserById(id);

            // if user not found return not found
            if (user == null)
            {
                return NotFound();
            }

            // if user found delete user

            return Ok(userService.DeleteUser(user));
        }

    }
}
