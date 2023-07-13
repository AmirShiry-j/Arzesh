using Application.FundService.Query;
using Application.IndustryService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly IGetIndustriesService _getIndustriesService;
        public IndustriesController(IGetIndustriesService getIndustriesService)
        {
            _getIndustriesService = getIndustriesService;
        }
        /// <summary>
        /// برگردوندن لیست صنایع و بخش ها ها برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take industries from service
            var result = await _getIndustriesService.Execute();

            return Ok(result.Data);
        }
    }
}
