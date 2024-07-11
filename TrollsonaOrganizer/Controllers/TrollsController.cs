using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TrollsonaOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace TrollsonaOrganizer.Controllers
{
	public class TrollsController : Controller
	{
		private readonly TrollsonaOrganizerContext _db;
		
		public TrollsController(TrollsonaOrganizerContext db)
		{
			_db = db;
		}
		
		public ActionResult Index()
		{
			List<Troll> model = _db.Trolls
				.Include(trollInstance => trollInstance.BloodCaste)
				.ToList();
			return View(model);
		}
		
		public ActionResult Create()
		{
			ViewBag.BloodCasteId = new SelectList(_db.BloodCastes, "BloodCasteId", "ColorName");
			return View();
		}
		
		[HttpPost]
		public ActionResult Create(Troll trollInstance)
		{
			if (trollInstance.BloodCasteId == 0)
			{
				return RedirectToAction("Create");
			}
			_db.Trolls.Add(trollInstance);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Details(int id)
		{
			Troll thisTroll = _db.Trolls
				.Include(trollInstance => trollInstance.BloodCaste)
				.Include(trollInstance => trollInstance.JoinEntities)
				.ThenInclude(join => join.StrifeSpecibus)
				.FirstOrDefault(trollInstance => trollInstance.TrollId == id);
			return View(thisTroll);
		}
		
		public ActionResult Edit(int id)
		{
			Troll thisTroll = _db.Trolls.FirstOrDefault(trollInstance => trollInstance.TrollId == id);
			ViewBag.BloodCasteId = new SelectList(_db.BloodCastes, "BloodCasteId", "ColorName");
			return View(thisTroll);
		}
		
		[HttpPost]
		public ActionResult Edit(Troll trollInstance)
		{
			_db.Trolls.Update(trollInstance);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult AddSpecibus(int id)
		{
			Troll thisTroll = _db.Trolls.FirstOrDefault(trollInstance => trollInstance.TrollId == id);
			ViewBag.StrifeSpecibusId = new SelectList(_db.StrifeSpecibi, "StrifeSpecibusId", "WeaponKind");
			return View(thisTroll);
		}
		
		[HttpPost]
		public ActionResult AddSpecibus(Troll trollInstance, int strifeSpecibusId)
		{
			bool joinEntityExists = _db.StrifePortfolios.Any(join => join.StrifeSpecibusId == strifeSpecibusId && join.TrollId == trollInstance.TrollId);
			if (!joinEntityExists && strifeSpecibusId != 0)
			{
				_db.StrifePortfolios.Add(new StrifePortfolio() { StrifeSpecibusId = strifeSpecibusId, TrollId = trollInstance.TrollId });
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new { id = trollInstance.TrollId});
		}
		
		public ActionResult Delete(int id)
		{
			Troll thisTroll = _db.Trolls.FirstOrDefault(trollInstance => trollInstance.TrollId == id);
			return View(thisTroll);
		}
		
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
				Troll thisTroll = _db.Trolls.FirstOrDefault(trollInstance => trollInstance.TrollId == id);
				_db.Trolls.Remove(thisTroll);
				_db.SaveChanges();
				return RedirectToAction("Index");
		}
		
		[HttpPost]
		public ActionResult DeleteJoin(int joinId)
		{
			StrifePortfolio joinEntry = _db.StrifePortfolios.FirstOrDefault(entry => entry.StrifePortfolioId == joinId);
			_db.StrifePortfolios.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}