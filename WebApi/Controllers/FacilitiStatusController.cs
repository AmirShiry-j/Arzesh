using Application.FacilitiNatureService.Query;
using Application.FacilitiStatusService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class FacilitiStatusController : ControllerBase
    {
        private readonly IGetFacilitiStatusService _getFacilitiStatusService;
        public FacilitiStatusController(IGetFacilitiStatusService getFacilitiStatusService)
        {
            _getFacilitiStatusService = getFacilitiStatusService;
        }
        /// <summary>
        /// برگردوندن لیست وضعیت های تسهیلات برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take facilitiStatuses from service
            var result = await _getFacilitiStatusService.Execute();

            return Ok(result.Data);
        }
    }
}
