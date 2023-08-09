using Application.Project_IncompletedService.Command;
using Application.Project_UnderCapacityService.Command;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project_UnderCapacity;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class Project_UnderCapacityController : ControllerBase
    {
        private readonly IAddProject_UnderCapacityService _addProject_UnderCapacityService;
        private readonly IMapper _mapper;

        public Project_UnderCapacityController(IAddProject_UnderCapacityService addProject_UnderCapacityService,
            IMapper mapper)
        {
            _addProject_UnderCapacityService = addProject_UnderCapacityService;
            _mapper = mapper;
        }
        /// <summary>
        /// ثبت یک پروژه (زیر ظرفیت) (Auth)
        /// </summary>
        /// <param name="CreateProjectDto"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProject_UnderCapacityApiDto CreateProjectDto)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            var inputService = _mapper.Map<CreateProject_UnderCapacityDto>(CreateProjectDto);

            //Create Project by service
            var resultService = await _addProject_UnderCapacityService.Execute(inputService, userId);

            if (resultService.IsSuccess)
            {
                //HATEOAS links
                string url = Url.Action("Get", "Project", new { ProjectId = resultService.Data }, Request.Scheme);

                return Created(url, "پروژه (زیر ظرفیت) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
