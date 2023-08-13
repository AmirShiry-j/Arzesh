using Application.DebtService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class DebtController : ControllerBase
    {
        private readonly IGetDebtsService _getDebtsService;
        public DebtController(IGetDebtsService getDebtsService)
        {
            _getDebtsService = getDebtsService;
        }
        /// <summary>
        /// برگردوندن سرفصل بدهی ها برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take datas from service
            var result = await _getDebtsService.Execute();

            return Ok(result.Data);
        }
    }
}