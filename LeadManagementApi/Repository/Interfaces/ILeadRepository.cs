using LeadManagementApi.Enums;
using LeadManagementApi.Models;

namespace LeadManagementApi.Repository.Interfaces
{
	public interface ILeadRepository
	{
		Task<List<Lead>> GetLeadsAsync();
		Task<bool> AcceptLeadAsync();
		Task<bool> DeclineLeadAsync();
		void SaveChanges();
	}
}
