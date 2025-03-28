using LeadManagementApi.Repository;
using LeadManagementApi.Repository.Context;
using LeadManagementApi.Repository.Interfaces;
using LeadManagementApi.Services;
using LeadManagementApi.Services.Interfaces;

namespace LeadManagementApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services) 
		{
			services.AddScoped<ILeadService, LeadService>();
			services.AddScoped<ILeadRepository, LeadRepository>();

			services.AddDbContext<LeadDbContext>();
			return services;
		}
	}
}
