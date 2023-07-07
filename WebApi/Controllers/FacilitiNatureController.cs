using Application.FacilitiNatureService.Query;
using Application.FundService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class FacilitiNatureController : ControllerBase
    {
        private readonly IGetFacilitiNatureService _getFacilitiNatureService;
        public FacilitiNatureController(IGetFacilitiNatureService getFacilitiNatureService)
        {
            _getFacilitiNatureService = getFacilitiNatureService;
        }
        /// <summary>
        /// برگردوندن لیست ماهیت های تسهیلات برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take facilitiNatures from service
            var result = await _getFacilitiNatureService.Execute();

            return Ok(result.Data);
        }
    }
}
