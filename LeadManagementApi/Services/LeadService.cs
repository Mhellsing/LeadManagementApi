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

		public async Task<LeadResponse> GetLeadsAsync()
		{
			List<Lead> leads = new();

			try
			{
				leads = await _leadRepository.GetLeadsAsync();

				if (!leads.Any())
				{					
					return new LeadResponse(MessageConstants.NoLeads, HttpStatusCode.NotFound, leads);
				}

				return new LeadResponse(MessageConstants.AllLeadsGet, HttpStatusCode.OK, leads);
			}
			catch (Exception ex)
			{
				_logger.LogError(MessageConstants.AnUnexpectedErrorOccurred, ex.Message, ex.StackTrace, ex.Source, ex.TargetSite);
				return new LeadResponse(MessageConstants.InternalError, HttpStatusCode.InternalServerError, leads);
			}
		}

		public async Task<LeadResponse> AcceptLeadAsync(int leadId)
		{
			throw new NotImplementedException();
		}

		public async Task<LeadResponse> DeclineLeadAsync(int leadId)
		{
			throw new NotImplementedException();
		}	
	}
}
