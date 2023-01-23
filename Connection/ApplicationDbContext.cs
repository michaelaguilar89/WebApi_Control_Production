using Microsoft.EntityFrameworkCore;
using WebApi_Control_Production.Models;

namespace WebApi_Control_Production.Connection
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
		{
		
		}

		public DbSet<Production> productions { get; set; }	
	}
}
