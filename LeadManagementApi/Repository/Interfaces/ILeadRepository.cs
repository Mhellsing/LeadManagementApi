using LeadManagementApi.Models;

namespace LeadManagementApi.Repository.Interfaces
{
	public interface ILeadRepository
	{
		Task<List<Lead>> GetLeadsWithStatusNewAsync();
		Task<List<Lead>> GetLeadsWithStatusAcceptedAsync();
		Task<bool> AcceptLeadAsync(Lead lead);
		Task<bool> DeclineLeadAsync(Lead lead);
	}
}
