using Application.Project_DevelopmentService.Command;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project_Development;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class Project_DevelopmentController : ControllerBase
    {
        private readonly IAddProject_DevelopmentService _addProject_DevelopmentService;
        private readonly IMapper _mapper;

        public Project_DevelopmentController(IAddProject_DevelopmentService addProject_DevelopmentService,
            IMapper mapper)
        {
            _addProject_DevelopmentService = addProject_DevelopmentService;
            _mapper = mapper;
        }
        /// <summary>
        /// ثبت یک پروژه (توسعه) (Auth)
        /// </summary>
        /// <param name="CreateProjectDto"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProject_DevelopmentApiDto CreateProjectDto)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            var inputService = _mapper.Map<CreateProject_DevelopmentDto>(CreateProjectDto);

            //Create Project by service
            var resultService = await _addProject_DevelopmentService.Execute(inputService, userId);

            if (resultService.IsSuccess)
            {
                //HATEOAS links
                string url = Url.Action("Get", "Project", new { ProjectId = resultService.Data }, Request.Scheme);

                return Created(url, "پروژه (توسعه) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
