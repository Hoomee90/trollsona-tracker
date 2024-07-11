using Microsoft.EntityFrameworkCore;

namespace TrollsonaOrganizer.Models
{
	public class TrollsonaOrganizerContext : DbContext
	{
		public DbSet<BloodCaste> BloodCastes { get; set; }
		public DbSet<Troll> Trolls { get; set; }
		public DbSet<StrifeSpecibus> StrifeSpecibi { get; set; }
		public DbSet<Allocation> Allocations { get; set; }

		public TrollsonaOrganizerContext(DbContextOptions options) : base(options) { }
	}
}