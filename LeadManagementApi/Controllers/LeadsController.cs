using LeadManagementApi.Messages;
using LeadManagementApi.Models;
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
			LeadResponse response = await _leadService.GetLeadsWithNewStatusAsync();

			return Ok(response);
		}

		[HttpPost]
		[Route("AcceptLead")]
		public async Task<IActionResult> Accept([FromBody] Lead lead)
		{
			if(lead.Id <= 0)
			{
				return BadRequest(MessageConstants.LeadIdMustBeGreaterThanZero);
			}

			_logger.LogInformation(MessageConstants.InitiatingAcceptLeadProcess);
			LeadResponse response = await _leadService.AcceptLeadAsync(lead);
			return Ok(response);
		}

		[HttpPost]
		[Route("DeclineLead")]
		public async Task<IActionResult> Decline([FromBody] Lead lead)
		{
			if (lead.Id <= 0)
			{
				return BadRequest(MessageConstants.LeadIdMustBeGreaterThanZero);
			}

			_logger.LogInformation(MessageConstants.InitiatingDeclineLeadProcess);
			LeadResponse response = await _leadService.DeclineLeadAsync(lead);
			return Ok(response);
		}
	}
}
