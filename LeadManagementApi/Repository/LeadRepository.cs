using LeadManagementApi.Models;
using LeadManagementApi.Repository.Context;
using LeadManagementApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeadManagementApi.Repository
{
	public class LeadRepository : ILeadRepository
	{
		private readonly LeadDbContext _context;

		public LeadRepository(LeadDbContext context)
		{
			_context = context;
		}

		public async Task<List<Lead>> GetLeadsAsync()
		{
			return await _context.Leads.ToListAsync();
		}

		public Task<bool> AcceptLeadAsync()
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeclineLeadAsync()
		{
			throw new NotImplementedException();
		}		

		public void SaveChanges()
		{
			throw new NotImplementedException();
		}
	}
}
