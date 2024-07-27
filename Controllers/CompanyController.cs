using AutoMapper;
using IdentityService.Attributes;
using IdentityService.Domain.Contract.Services;
using IdentityService.Domain.Entities;
using IdentityService.Dtos.RequestDtos.Company;
using IdentityService.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IdentityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeRoles("SuperAdmin")]
    public class CompanyController(IService service, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(mapper.Map<List<CompanyDto>>(await service.GetAll<Company>(null)));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyCreateDto dto)
        {
            var userClaims = HttpContext.User;

            var userId = userClaims.GetGuidClaimValue("Id");

            dto.SetCreatedBy(userId);

            var company = mapper.Map<Company>(dto);

            await service.AddNew(company);

            return Created("", mapper.Map<CompanyDto>(company));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var company = await service.GetById<Company>(id);

            if (company == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CompanyDto>(await service.GetById<Company>(id)));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var companyToBeDeleted = await service.GetById<Company>(id);

            if (companyToBeDeleted == null)
            {
                return NotFound();
            }

            var userClaims = HttpContext.User;

            var userId = userClaims.GetGuidClaimValue("Id");

            companyToBeDeleted.DeletedById = (userId);


            await service.Remove(companyToBeDeleted);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(CompanyUpdateDto updateDto)
        {
            var companyToBeUpdated = await service.GetById<Company>(updateDto.Id);

            if (companyToBeUpdated == null)
            {
                return NotFound();
            }

            var userClaims = HttpContext.User;

            var userId = userClaims.GetGuidClaimValue("Id");

            updateDto.SetUpdatedBy(userId);

            await service.Update(mapper.Map<Company>(updateDto));

            return Ok();
        }

    }
}
