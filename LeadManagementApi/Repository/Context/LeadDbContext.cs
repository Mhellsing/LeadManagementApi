using LeadManagementApi.Messages;
using LeadManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LeadManagementApi.Repository.Context
{
	public class LeadDbContext : DbContext
	{
		private IConfiguration _configuration;
		private ILogger<LeadDbContext> _logger;

		public DbSet<Lead> Leads { get; set; }

		public LeadDbContext(IConfiguration configuration, ILogger<LeadDbContext> logger, DbContextOptions options) : base(options)
		{
			_configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_logger = logger;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string typeDataBase = _configuration.GetValue<string>("TypeDatabase");
			string? connectionString = _configuration.GetConnectionString(typeDataBase);
			optionsBuilder.UseSqlServer(connectionString);

			if (connectionString.IsNullOrEmpty())
			{
				_logger.LogError(MessageConstants.ConnectionStringNotConfigured, typeDataBase);
				throw new InvalidOperationException();
			}
		}
	}
}
