using CourseworkUI.Models;
using CourseworkUI.Models.Clients;
using CourseworkUI.Models.Employees;
using CourseworkUI.Models.Users.Clients;
using CourseworkUI.Models.Users.Employees;
using Microsoft.EntityFrameworkCore;

namespace CourseworkUI.Services
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Client> Clients { get; set; } = null!;
		public DbSet<NaturalPerson> NaturalPersons { get; set; } = null!;
		public DbSet<LegalPerson> LegalPersons { get; set; } = null!;
		public DbSet<Employee> Employees { get; set; } = null!;
		public DbSet<Accountant> Accountants { get; set; } = null!;
		public DbSet<Admin> Admins { get; set; } = null!;
		public DbSet<InsuranceAgent> InsuranceAgents { get; set; } = null!;
		public DbSet<Manager> Managers { get; set; } = null!;
		public DbSet<TypeOfInsurance> TypesOfInsurances { get; set; } = null!;
		public DbSet<InsuranceRisk> InsuranceRisks { get; set; } = null!;
		public DbSet<ClientApplication> ClientApplications { get; set; } = null!;
		public DbSet<Message> Messages { get; set; } = null!;
		public DbSet<Policy> Polices { get; set; } = null!;
		public DbSet<Economist> Economists { get; set; } = null!;
		public DbSet<MonthlyPayment> MonthlyPayments { get; set; } = null!;

		public ApplicationContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=coursework;Trusted_Connection=True;");
			optionsBuilder.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasIndex(p => new { p.Username })
				.IsUnique();
			modelBuilder.Entity<TypeOfInsurance>()
				.HasIndex(p => new { p.Name })
				.IsUnique();
			modelBuilder.Entity<InsuranceRisk>()
				.HasIndex(p => new { p.Name })
				.IsUnique();
		}
	}
}
