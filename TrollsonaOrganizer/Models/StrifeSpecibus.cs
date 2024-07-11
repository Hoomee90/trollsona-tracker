using System.Collections.Generic;

namespace TrollsonaOrganizer.Models
{
	public class StrifeSpecibus
	{
		public int StrifeSpecibusId { get; set; }
		public string WeaponKind { get; set; }
		public List<StrifePortfolio> JoinEntities { get; }
	}
}