using Application.FundService.Query;
using Application.RentTypeService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class RentTypeController : ControllerBase
    {
        private readonly IGetRentTypeService _getRentTypeService;
        public RentTypeController(IGetRentTypeService getRentTypeService)
        {
            _getRentTypeService = getRentTypeService;
        }
        /// <summary>
        /// برگردوندن انواع اجاره ها برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take rentTypes from service
            var result = await _getRentTypeService.Execute();

            return Ok(result.Data);
        }
    }
}
