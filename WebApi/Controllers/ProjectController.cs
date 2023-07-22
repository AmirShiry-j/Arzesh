using Application.Common;
using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using Application.Project_Service.Command;
using Application.Project_Service.Query;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project;
using WebApi.ModelsAndDtoes.Project_Ideh;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDeleteProjectService _deleteProjectService;
        private readonly IGetAllProjectForUser _getAllProjectForUser;
        private readonly IGetProjectsWithSearch _getProjectsWithSearch;
        private readonly IGetProjectById _getProjectById;
        private readonly IMapper _mapper;

        public ProjectController(IDeleteProjectService deleteProjectService,
            IGetAllProjectForUser getAllProjectForUser,
            IGetProjectsWithSearch getProjectsWithSearch,
            IGetProjectById getProjectById,
            IMapper mapper)
        {
            _deleteProjectService = deleteProjectService;
            _getAllProjectForUser = getAllProjectForUser;
            _getProjectsWithSearch = getProjectsWithSearch;
            _getProjectById = getProjectById;
            _mapper = mapper;
        }

        /// <summary>
        /// بر گردوندن پروژه ها
        /// </summary>
        /// <param name="SearchProjectApiDto"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] SearchProjectApiDto SearchProjectApiDto)
        {
            //Map
            var inputService = _mapper.Map<SearchProjectDto>(SearchProjectApiDto);

            //Get data from service
            var resultService = await _getProjectsWithSearch.Execute(inputService);

            //HATEAOS
            foreach (var project in resultService.Data.Projects)
            {

                project.Link = new Link
                {
                    For = "Details",
                    HttpMethod = HttpMethod.Get.ToString(),
                    Url = Url.Action(nameof(Get), "Project", new { ProjectId = project.Id }, Request.Scheme)
                };
            }

            return Ok(resultService.Data);
        }

        /// <summary>
        /// بر گردوندن جزئیات اطلاعات یک پروژه
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [HttpGet("{ProjectId}")]
        public async Task<IActionResult> Get(int ProjectId)
        {
            //Get data from service
            var resultService = await _getProjectById.Execute(ProjectId);

            if (resultService.IsSuccess)
            {
                return Ok(resultService.Data);
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }


        /// <summary>
        /// بر گردوندن همه پروژه های ایجاد شده توسط کاربر لاگین شده (Auth)
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("~/api/v{version:apiVersion}/[controller]/[action]/")]
        //[HttpGet]
        public async Task<IActionResult> GetUserProjects()
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            //Get data from service
            var resultService = await _getAllProjectForUser.Execute(userId);

            //HATEAOS
            foreach (var project in resultService.Data)
            {

                project.Link = new Link
                {
                    For = "Delete",
                    HttpMethod = HttpMethod.Delete.ToString(),
                    Url = Url.Action("Delete", "Project", new { ProjectId = project.Id }, Request.Scheme)
                };
            }

            return Ok(resultService.Data);
        }

        /// <summary>
        /// حذف یک پروژه
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
            var resultService = await _deleteProjectService.Execute(ProjectId, userId);

            if (resultService.IsSuccess)
            {
                return Ok("پروژه شما حذف گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
