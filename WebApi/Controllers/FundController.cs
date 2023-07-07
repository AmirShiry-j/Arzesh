using Application.FundService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class FundController : ControllerBase
    {
        private readonly IGetFundsService _getFundsService;
        public FundController(IGetFundsService getFundsService)
        {
            _getFundsService = getFundsService;
        }
        /// <summary>
        /// برگردوندن لیست سرمایه گذاری ها برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take funds from service
            var result = await _getFundsService.Execute();

            return Ok(result.Data);
        }
    }
}
