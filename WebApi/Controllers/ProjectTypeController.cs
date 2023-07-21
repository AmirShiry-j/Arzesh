using Application.FundService.Query;
using Application.ProjectTypeService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class ProjectTypeController : ControllerBase
    {
        private readonly IGetProjectTypesService _getProjectTypesService;
        public ProjectTypeController(IGetProjectTypesService getProjectTypesService)
        {
            _getProjectTypesService = getProjectTypesService;
        }
        /// <summary>
        /// برگردوندن انواع پروژه ها برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take projectTypes from service
            var result = await _getProjectTypesService.Execute();

            return Ok(result.Data);
        }
    }
}
