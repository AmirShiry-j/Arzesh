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
        /// برگردوندن اطلاعات یک پروژه (ایده) با آیدی
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpGet("{ProjectId}")]
        //public async Task<IActionResult> Get(int ProjectId)
        //{
        //    //Get UserId
        //    var userId = User.Claims?.FirstOrDefault(p => p.Type == "UserId")?.Value;

        //    //Get data from service
        //    var resultService = await _getProject_IdehById.Execute(ProjectId, userId);

        //    if (resultService.IsSuccess)
        //    {
        //        ////HATEOAS links
        //        //For Self
        //        resultService.Data.Links = new List<Link>
        //        {
        //            new Link
        //            {
        //                For="Delete",
        //                HttpMethod=HttpMethod.Delete.ToString(),
        //                Url=Url.Action("Delete","Project",new {ProjectId=ProjectId },Request.Scheme)
        //            },
        //        };

        //        return Ok(resultService.Data);
        //    }
        //    else
        //    {
        //        return BadRequest(resultService.Message);
        //    }
        //}

        /// <summary>
        /// ثبت یک پروژه (ایده)
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
                string url = "";

                return Created(url, "پروژه (ایده) شما ثبت گردید");
            }
            else
            {
                return BadRequest(resultService.Message);
            }
        }
    }
}
