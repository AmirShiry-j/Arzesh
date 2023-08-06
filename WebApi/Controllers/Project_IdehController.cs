using Application.Common;
using Application.Project_IdehService.Command;
using Application.Project_IdehService.Query;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project_Ideh;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class Project_IdehController : ControllerBase
    {
        private readonly IAddProject_IdehService _addProject_IdehService;
        private readonly IGetProject_IdehById _getProject_IdehById;
        private readonly IMapper _mapper;

        public Project_IdehController(IAddProject_IdehService addProject_IdehService,
            IGetProject_IdehById getProject_IdehById,
            IMapper mapper)
        {
            _addProject_IdehService = addProject_IdehService;
            _getProject_IdehById = getProject_IdehById;
            _mapper = mapper;
        }


        /// <summary>
        /// ثبت یک پروژه (ایده) (Auth)
        /// </summary>
        /// <param name="CreateProjectDto"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> Post(CreateProject_IdehApiDto CreateProjectDto)
        {
            //Get UserId
            var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

            var inputService = _mapper.Map<CreateProject_IdehDto>(CreateProjectDto);

            //Create Project by service
            var resultService = await _addProject_IdehService.Execute(inputService, userId);

            if (resultService.IsSuccess)
            {
                //HATEOAS links
                string url = Url.Action("Get", "Project", new { ProjectId = resultService.Data }, Request.Scheme);

                return Created(url, "پروژه (ایده) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
