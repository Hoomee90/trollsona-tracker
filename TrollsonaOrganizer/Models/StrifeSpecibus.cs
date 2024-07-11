using System.Collections.Generic;

namespace TrollsonaOrganizer.Models
{
	public class StrifeSpecibus
	{
		public int StrifeSpecibusId { get; set; }
		public string KindAbstratus { get; set; }
		public List<Allocation> JoinEntities { get; }
	}
}