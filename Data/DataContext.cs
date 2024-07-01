using ListProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ListProject.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }
	}
}

