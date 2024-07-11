using System.Collections.Generic;

namespace TrollsonaOrganizer.Models
{
	public class Troll
	{
		public int TrollId { get; set; }
		public string Name { get; set; }
		public string Sign { get; set; }
		public int Age { get; set; }
		public int BloodCasteId { get; set; }
		public BloodCaste BloodCaste { get; set; }
		public List<StrifePortfolio> JoinEntities { get; }
	}
}