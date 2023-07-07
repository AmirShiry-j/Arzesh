using Application.FundService.Query;
using Application.LicenceService.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class LicenceController : ControllerBase
    {
        private readonly IGetLicencesService _getLicencesService;
        public LicenceController(IGetLicencesService getLicencesService)
        {
            _getLicencesService = getLicencesService;
        }
        /// <summary>
        /// برگردوندن لیست مجوز ها برای کمبوباکس
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //Take licences from service
            var result = await _getLicencesService.Execute();

            return Ok(result.Data);
        }
    }
}
