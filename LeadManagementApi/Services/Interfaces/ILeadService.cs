using LeadManagementApi.Models;
using LeadManagementApi.Models.Responses;

namespace LeadManagementApi.Services.Interfaces
{
	public interface ILeadService
	{
		Task<LeadResponse> GetLeadsWithStatusNewAsync();
		Task<LeadResponse> GetLeadsWithStatusAcceptedAsync();
		Task<LeadResponse> AcceptLeadAsync(Lead lead);
		Task<LeadResponse> DeclineLeadAsync(Lead lead);
	}
}
