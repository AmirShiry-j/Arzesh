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

        public ProjectController(IDeleteProjectService deleteProjectService,
            IGetAllProjectForUser getAllProjectForUser)
        {
            _deleteProjectService = deleteProjectService;
            _getAllProjectForUser= getAllProjectForUser;
        }

        /// <summary>
        /// بر گردوندن همه پروژه های ایجاد شده توسط کاربر (Auth)
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> Get()
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
