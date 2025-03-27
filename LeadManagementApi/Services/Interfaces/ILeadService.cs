using LeadManagementApi.Models.Responses;

namespace LeadManagementApi.Services.Interfaces
{
	public interface ILeadService
	{
		Task<LeadResponse> GetLeadsAsync();
		Task<LeadResponse> AcceptLeadAsync(int leadId);
		Task<LeadResponse> DeclineLeadAsync(int leadId);
	}
}
