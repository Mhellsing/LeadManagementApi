using LeadManagementApi.Enums;
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

		public async Task<List<Lead>> GetLeadsWithStatusNewAsync()
		{
			return await _context.Leads
				.Where(x => x.Status == LeadStatus.New)
				.ToListAsync();
		}

		public async Task<List<Lead>> GetLeadsWithStatusAcceptedAsync()
		{
			return await _context.Leads
				.Where(x => x.Status == LeadStatus.Accepted)
				.ToListAsync();
		}

		public async Task<bool> AcceptLeadAsync(Lead lead)
		{
			int rowsUpdated = await _context.Leads
				.Where(x => x.Id == lead.Id)
				.ExecuteUpdateAsync(y => y
					.SetProperty(lead => lead.Status, LeadStatus.Accepted)
					.SetProperty(lead => lead.Price, lead.Price));

			return rowsUpdated > 0;
		}

		public async Task<bool> DeclineLeadAsync(Lead lead)
		{
			int rowsUpdated = await _context.Leads
				.Where(x => x.Id == lead.Id)
				.ExecuteUpdateAsync(y => y
					.SetProperty(lead => lead.Status, LeadStatus.Declined));

			return rowsUpdated > 0;
		}
	}
}
