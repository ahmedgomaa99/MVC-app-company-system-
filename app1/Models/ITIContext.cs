using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace app1.Models
{
	public class ITIContext:IdentityDbContext<ApplicationUser>
	{
		public ITIContext() : base()
		{

		}
		public ITIContext(DbContextOptions options):base(options) 
		{

		}
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=itidb2;Integrated Security=True;Encrypt=False");
		//	base.OnConfiguring(optionsBuilder);

		//}
		public DbSet<Employee> Employees { get; set; }	
		public DbSet<Department> Departments { get; set; }
	}
}
