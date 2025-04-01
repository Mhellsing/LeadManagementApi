using LeadManagementApi.Enums;
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
		[Route("GetLeadsWithStatusNew")]
		public async Task<IActionResult> GetLeadsWithStatusNew()
		{
			_logger.LogInformation(MessageConstants.InitiatingProcessToGetAllLeadsWithStatusNew);
			LeadResponse response = await _leadService.GetLeadsWithStatusNewAsync();

			return Ok(response);
		}

		[HttpGet]
		[Route("GetLeadsWithStatusAccepted")]
		public async Task<IActionResult> GetLeadsWithStatusAccepted()
		{
			_logger.LogInformation(MessageConstants.InitiatingProcessToGetAllLeadsWithStatusNew);
			LeadResponse response = await _leadService.GetLeadsWithStatusAcceptedAsync();

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

			if (lead.Status != LeadStatus.New)
			{
				return BadRequest(MessageConstants.WrongStatusToAcceptOrDecline);
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

			if (lead.Status != LeadStatus.New)
			{
				return BadRequest(MessageConstants.WrongStatusToAcceptOrDecline);
			}

			_logger.LogInformation(MessageConstants.InitiatingDeclineLeadProcess);
			LeadResponse response = await _leadService.DeclineLeadAsync(lead);
			return Ok(response);
		}
	}
}
