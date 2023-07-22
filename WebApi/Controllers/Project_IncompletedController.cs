using Application.Project_IncompletedService.Command;
using Application.Project_IncompletedService.Query;
using Application.Project_IncompletedService.Query;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ModelsAndDtoes.Project_Incompleted;
using Application.Common;
using Application.Project_Service.Command;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class Project_IncompletedController : ControllerBase
    {
        private readonly IAddProject_IncompletedService _addProject_IncompletedService;
        private readonly IGetProject_IncompletedById _getProject_IncompletedById;
        private readonly IMapper _mapper;

        public Project_IncompletedController(IAddProject_IncompletedService addProject_IncompletedService,
            IGetProject_IncompletedById getProject_IncompletedById,
            IMapper mapper)
        {
            _addProject_IncompletedService = addProject_IncompletedService;
            _getProject_IncompletedById = getProject_IncompletedById;
            _mapper = mapper;
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
                string url = "";

                return Created(url, "پروژه (نیمه تمام) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
