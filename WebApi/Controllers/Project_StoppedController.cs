using Application.Project_StoppedService.Command;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project_Stopped;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class Project_StoppedController : ControllerBase
    {
        private readonly IAddProject_StoppedService _addProject_StoppedService;
        private readonly IMapper _mapper;

        public Project_StoppedController(IAddProject_StoppedService addProject_StoppedService,
            IMapper mapper)
        {
            _addProject_StoppedService = addProject_StoppedService;
            _mapper = mapper;
        }
        /// <summary>
        /// ثبت یک پروژه (متوقف شده / غیر فعال) (Auth)
        /// </summary>
        /// <param name="CreateProjectDto"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProject_StoppedApiDto CreateProjectDto)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            var inputService = _mapper.Map<CreateProject_StoppedDto>(CreateProjectDto);

            //Create Project by service
            var resultService = await _addProject_StoppedService.Execute(inputService, userId);

            if (resultService.IsSuccess)
            {
                //HATEOAS links
                string url = Url.Action("Get", "Project", new { ProjectId = resultService.Data }, Request.Scheme);

                return Created(url, "پروژه (متوقف شده / غیر فعال) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
