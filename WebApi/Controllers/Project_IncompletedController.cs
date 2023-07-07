using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project_Incompleted;
using Application.Common;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class Project_IncompletedController : ControllerBase
    {
        private readonly IAddProject_IncompletedService _addProject_IncompletedService;
        private readonly IDeleteProject_IncompletedService _deleteProject_IncompletedService;
        private readonly IGetProject_IncompletedById _getProject_IncompletedById;
        private readonly IGetAllProject_IncompletedForUser _getAllProject_IncompletedForUser;
        private readonly IMapper _mapper;

        public Project_IncompletedController(IAddProject_IncompletedService addProject_IncompletedService,
            IDeleteProject_IncompletedService deleteProject_IncompletedService,
            IGetProject_IncompletedById getProject_IncompletedById,
            IGetAllProject_IncompletedForUser getAllProject_IncompletedForUser,
            IMapper mapper)
        {
            _addProject_IncompletedService = addProject_IncompletedService;
            _deleteProject_IncompletedService = deleteProject_IncompletedService;
            _getAllProject_IncompletedForUser = getAllProject_IncompletedForUser;
            _getProject_IncompletedById = getProject_IncompletedById;
            _mapper = mapper;
        }

        /// <summary>
        /// برگردوندن لیست پروژه ها (نیمه تمام)
        /// </summary>
        /// <param name="SearchDto"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchProject_IncompletedApiDto SearchDto)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            //map
            var inputService = _mapper.Map<SearchProject_IncompletedDto>(SearchDto);

            //Get data from service
            var resultService = await _getAllProject_IncompletedForUser.Execute(inputService, userId);

            //HATEAOS

            foreach (var project in resultService.Data.Projects)
            {

                project.Link = new Link
                {
                    For = "Details",
                    HttpMethod = HttpMethod.Get.ToString(),
                    Url = Url.Action(nameof(Get), "Project_Incompleted", new { ProjectId = project.Id }, Request.Scheme)
                };
            }

            return Ok(resultService.Data);
        }

        /// <summary>
        /// برگردوندن اطلاعات یک پروژه (نیمه تمام) با آیدی
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{ProjectId}")]
        public async Task<IActionResult> Get(int ProjectId)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            //Get data from service
            var resultService = await _getProject_IncompletedById.Execute(ProjectId, userId);

            if (resultService.IsSuccess)
            {
                ////HATEOAS links
                //For Self
                resultService.Data.Links = new List<Link>
                {
                    new Link
                    {
                        For="Delete",
                        HttpMethod=HttpMethod.Delete.ToString(),
                        Url=Url.Action(nameof(Delete),"Project_Incompleted",new {ProjectId=ProjectId },Request.Scheme)
                    },
                };

                return Ok(resultService.Data);
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }

        /// <summary>
        /// ثبت یک پروژه (نیمه تمام)
        /// </summary>
        /// <param name="CreateProjectDto"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProject_IncompletedApiDto CreateProjectDto)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            var inputService = _mapper.Map<CreateProject_IncompletedDto>(CreateProjectDto);

            //Create Project by service
            var resultService = await _addProject_IncompletedService.Execute(inputService, userId);

            if (resultService.IsSuccess)
            {
                //HATEOAS links
                string url = Url.Action(nameof(Get), "Project_Incompleted", new { ProjectId = resultService.Data }, Request.Scheme);

                return Created(url, "پروژه (نیمه تمام) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }

        /// <summary>
        /// حذف یک پروژه (نیمه تمام)
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{ProjectId}")]
        public async Task<IActionResult> Delete(int ProjectId)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            //Delete Project by service
            var resultService = await _deleteProject_IncompletedService.Execute(ProjectId, userId);

            if (resultService.IsSuccess)
            {
                return Ok("پروژه (نیمه تمام) شما حذف گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
