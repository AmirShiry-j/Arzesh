using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using Application.Project_Service.Command;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IDeleteProjectService _deleteProjectService;

        public ProjectController(IDeleteProjectService deleteProjectService)
        {
            _deleteProjectService = deleteProjectService;
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
