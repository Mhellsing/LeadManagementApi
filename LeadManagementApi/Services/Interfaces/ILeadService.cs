using LeadManagementApi.Models;
using LeadManagementApi.Models.Responses;

namespace LeadManagementApi.Services.Interfaces
{
	public interface ILeadService
	{
		Task<LeadResponse> GetLeadsWithNewStatusAsync();
		Task<LeadResponse> GetLeadsWithAcceptedStatusAsync();
		Task<LeadResponse> AcceptLeadAsync(Lead lead);
		Task<LeadResponse> DeclineLeadAsync(Lead lead);
	}
}
