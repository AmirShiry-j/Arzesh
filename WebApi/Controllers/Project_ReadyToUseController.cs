using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using Application.Project_ReadyToUseService.Command;
using AutoMapper;
using Domain.Projects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project__ReadyToUse;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]

    public class Project_ReadyToUseController : ControllerBase
    {
        private readonly IAddProject_ReadyToUseService _addProject_ReadyToUseService;
        private readonly IMapper _mapper;

        public Project_ReadyToUseController(IAddProject_ReadyToUseService addProject_ReadyToUseService,
            IMapper mapper)
        {
            _addProject_ReadyToUseService = addProject_ReadyToUseService;
            _mapper = mapper;
        }


        /// <summary>
        /// ثبت یک پروژه (آماده بهره برداری) (Auth)
        /// </summary>
        /// <param name="CreateProjectDto"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProject_ReadyToUseApiDto CreateProjectDto)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            var inputService = _mapper.Map<CreateProject_ReadyToUseDto>(CreateProjectDto);

            //Create Project by service
            var resultService = await _addProject_ReadyToUseService.Execute(inputService, userId);

            if (resultService.IsSuccess)
            {
                //HATEOAS links
                string url = Url.Action("Get", "Project", new { ProjectId = resultService.Data }, Request.Scheme);

                return Created(url, "پروژه (آماده بهره برداری) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
