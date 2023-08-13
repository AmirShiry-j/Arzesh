using Application.InactivityReasonService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class InactivityReasonController : ControllerBase
    {
        private readonly IGetInactivityReasonsService _getInactivityReasonsService;
        public InactivityReasonController(IGetInactivityReasonsService getInactivityReasonsService)
        {
            _getInactivityReasonsService = getInactivityReasonsService;
        }
        /// <summary>
        /// برگردوندن لیست دلایل توقف برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take datas from service
            var result = await _getInactivityReasonsService.Execute();

            return Ok(result.Data);
        }
    }
}
