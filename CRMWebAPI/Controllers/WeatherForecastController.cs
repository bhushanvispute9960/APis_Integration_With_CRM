using CRMWebAPI.BAL;
using CRMWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace CRMWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly CRMDynamicService _dynamicsService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, CRMDynamicService dynamicsService)
        {
            _logger = logger;
            _dynamicsService = dynamicsService;
        }


        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                var accounts = await _dynamicsService.GetAccountsAsync();
                return Ok(accounts);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("leads")]
        public async Task<IActionResult> GetLeads()
        {
            try
            {
                var leads = await _dynamicsService.GetLeadsAsync();
                return Ok(leads);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("leads/{versionNumber}")]
        public async Task<IActionResult> GetDealInformation(int versionNumber)
        {
            try
            {
                var dealInformation = await _dynamicsService.GetDealInformationByDealNumber(versionNumber);
                if (dealInformation == null) return NotFound();
                return Ok(dealInformation);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Lead lead)
        {
            try
            {
                var success = await _dynamicsService.InsertLeadAsync(lead);

                if (success)
                {
                    return Ok("Lead created successfully.");
                }
                else
                {
                    return BadRequest("Failed to create the lead.");
                }
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
