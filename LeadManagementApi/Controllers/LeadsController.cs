using LeadManagementApi.Messages;
using LeadManagementApi.Models.Responses;
using LeadManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagementApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class LeadsController : ControllerBase
	{
		private readonly ILeadService _leadService;
		private readonly ILogger<LeadsController> _logger;

		public LeadsController(ILeadService leadService, ILogger<LeadsController> logger)
		{
			_leadService = leadService;
			_logger = logger;
		}

		[HttpGet]
		[Route("GetLeads")]
		public async Task<IActionResult> GetLeads()
		{
			_logger.LogInformation(MessageConstants.GetLeads);
			LeadResponse response = await _leadService.GetLeadsAsync();

			return Ok(response);
		}

		[HttpPost]
		[Route("AcceptLead")]
		public async Task<IActionResult> Accept([FromBody] int leadId)
		{
			_logger.LogInformation(MessageConstants.AcceptLead);
			LeadResponse response = await _leadService.AcceptLeadAsync(leadId);
			return Ok(response);
		}

		[HttpPost]
		[Route("DeclineLead")]
		public async Task<IActionResult> Decline([FromBody] int leadId)
		{
			_logger.LogInformation(MessageConstants.DeclineLead);
			LeadResponse response = await _leadService.DeclineLeadAsync(leadId);
			return Ok(response);
		}
	}
}
