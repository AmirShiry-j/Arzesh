using Application.AssetService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IGetAssetsService _getAssetsService;
        public AssetController(IGetAssetsService getAssetsService)
        {
            _getAssetsService = getAssetsService;
        }
        /// <summary>
        /// برگردوندن لیست دارایی ها برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take assets from service
            var result = await _getAssetsService.Execute();

            return Ok(result.Data);
        }
    }
}
