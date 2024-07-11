namespace TrollsonaOrganizer.Models
{
	public class StrifePortfolio
	{
		public int StrifePortfolioId { get; set; }
		public int TrollId { get; set; }
		public Troll Troll { get; set; }
		public int StrifeSpecibusId { get; set; }
		public StrifeSpecibus StrifeSpecibus { get; set; }
	}
}