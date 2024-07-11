using System.Collections.Generic;

namespace TrollsonaOrganizer.Models
{
	public class BloodCaste
	{
		public int BloodCasteId { get; set; }
		public string ColorName { get; set; }
		public string ColorHex { get; set; }
		public string Division { get; set; }
		public List<Troll> Trolls { get; set; }
	}
}