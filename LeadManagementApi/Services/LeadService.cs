using LeadManagementApi.Messages;
using LeadManagementApi.Models;
using LeadManagementApi.Models.Responses;
using LeadManagementApi.Repository.Interfaces;
using LeadManagementApi.Services.Interfaces;
using System.Net;

namespace LeadManagementApi.Services
{
	public class LeadService : ILeadService
	{
		private readonly ILeadRepository _leadRepository;
		private readonly ILogger<LeadService> _logger;

		public LeadService(ILeadRepository leadRepository, ILogger<LeadService> logger)
		{
			_leadRepository = leadRepository;
			_logger = logger;
		}

		public async Task<LeadResponse> GetLeadsWithStatusNewAsync()
		{
			List<Lead> leads = new();

			try
			{
				leads = await _leadRepository.GetLeadsWithStatusNewAsync();

				if (!leads.Any())
				{					
					return new LeadResponse(MessageConstants.NoLeads, HttpStatusCode.NotFound, leads);
				}

				_logger.LogInformation(MessageConstants.FinishingProcessToGetAllLeadsWithStatusNew);
				return new LeadResponse(MessageConstants.AllLeadsWithNewStatusGet, HttpStatusCode.OK, leads);
			}
			catch (Exception ex)
			{
				_logger.LogError(MessageConstants.AnUnexpectedErrorOccurred, ex.Message, ex.StackTrace, ex.Source, ex.TargetSite);
				return new LeadResponse(MessageConstants.InternalError, HttpStatusCode.InternalServerError, leads);
			}
		}

		public async Task<LeadResponse> GetLeadsWithStatusAcceptedAsync()
		{
			List<Lead> leads = new();

			try
			{
				leads = await _leadRepository.GetLeadsWithStatusAcceptedAsync();

				if (!leads.Any())
				{
					return new LeadResponse(MessageConstants.NoLeads, HttpStatusCode.NotFound, leads);
				}

				_logger.LogInformation(MessageConstants.FinishingProcessToGetAllLeadsWithStatusNew);
				return new LeadResponse(MessageConstants.AllLeadsWithAcceptedStatusGet, HttpStatusCode.OK, leads);
			}
			catch (Exception ex)
			{
				_logger.LogError(MessageConstants.AnUnexpectedErrorOccurred, ex.Message, ex.StackTrace, ex.Source, ex.TargetSite);
				return new LeadResponse(MessageConstants.InternalError, HttpStatusCode.InternalServerError, leads);
			}
		}

		public async Task<LeadResponse> AcceptLeadAsync(Lead lead)
		{
			List<Lead> leads = new();

			try
			{
				if(lead.Price > 500)
				{
					lead.ApplyTenPercentDiscountToLeadPrice();
				}				

				bool rowsUpdated = await _leadRepository.AcceptLeadAsync(lead);
				
				if (!rowsUpdated)
				{
					return new LeadResponse(MessageConstants.LeadAcceptanceFailed, HttpStatusCode.BadRequest, leads);
				}

				_logger.LogInformation(MessageConstants.FinishingLeadAcceptProcess);
				return new LeadResponse(MessageConstants.LeadAccepted, HttpStatusCode.OK, leads);
			}
			catch (Exception ex)
			{
				_logger.LogError(MessageConstants.AnUnexpectedErrorOccurred, ex.Message, ex.StackTrace, ex.Source, ex.TargetSite);
				return new LeadResponse(MessageConstants.InternalError, HttpStatusCode.InternalServerError, leads);
			}
		}

		public async Task<LeadResponse> DeclineLeadAsync(Lead lead)
		{
			List<Lead> leads = new();

			try
			{
				bool rowsUpdated = await _leadRepository.DeclineLeadAsync(lead);

				if (!rowsUpdated)
				{
					return new LeadResponse(MessageConstants.LeadDeclineFailed, HttpStatusCode.BadRequest, leads);
				}

				_logger.LogInformation(MessageConstants.FinishingLeadDeclineProcess);
				return new LeadResponse(MessageConstants.LeadDeclined, HttpStatusCode.OK, leads);
			}
			catch (Exception ex)
			{
				_logger.LogError(MessageConstants.AnUnexpectedErrorOccurred, ex.Message, ex.StackTrace, ex.Source, ex.TargetSite);
				return new LeadResponse(MessageConstants.InternalError, HttpStatusCode.InternalServerError, leads);
			}			
		}	
	}
}
