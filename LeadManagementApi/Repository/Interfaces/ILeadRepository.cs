using LeadManagementApi.Models;

namespace LeadManagementApi.Repository.Interfaces
{
	public interface ILeadRepository
	{
		Task<List<Lead>> GetLeadsWithNewStatusAsync();
		Task<List<Lead>> GetLeadsWithAcceptedStatusAsync();
		Task<bool> AcceptLeadAsync(Lead lead);
		Task<bool> DeclineLeadAsync(Lead lead);
	}
}
