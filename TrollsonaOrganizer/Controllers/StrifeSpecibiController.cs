using Microsoft.AspNetCore.Mvc;
using TrollsonaOrganizer.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace TrollsonaOrganizer.Controllers
{
	public class StrifeSpecibiController : Controller
	{
		private readonly TrollsonaOrganizerContext _db;

		public StrifeSpecibiController(TrollsonaOrganizerContext db)
		{
			_db = db;
		}

		public ActionResult Index()
		{
			return View(_db.StrifeSpecibi.ToList());
		}
		
		public ActionResult Details(int id)
		{
			StrifeSpecibus thisStrife = _db.StrifeSpecibi
				.Include(strifeInstance => strifeInstance.JoinEntities)
				.ThenInclude(join => join.Troll)
				.FirstOrDefault(strifeInstance => strifeInstance.StrifeSpecibusId == id);
			return View(thisStrife);
		}
		
		public ActionResult Create()
		{
			return View();
		}
		
		[HttpPost]
		public ActionResult Create(StrifeSpecibus strifeInstance)
		{
			_db.StrifeSpecibi.Add(strifeInstance);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult AddTroll(int id)
		{
			StrifeSpecibus thisStrife = _db.StrifeSpecibi.FirstOrDefault(strifeInstance => strifeInstance.StrifeSpecibusId == id);
			ViewBag.TrollId = new SelectList(_db.Trolls, "TrollId", "Name");
			return View(thisStrife);
		}
		
		[HttpPost]
		public ActionResult AddTroll(StrifeSpecibus strifeInstance, int trollId)
		{
			bool joinEntityExists = _db.StrifePortfolios.Any(join => join.TrollId == trollId && join.StrifeSpecibusId == strifeInstance.StrifeSpecibusId);
			if (!joinEntityExists && trollId != 0)
			{
				_db.StrifePortfolios.Add(new StrifePortfolio() { TrollId = trollId, StrifeSpecibusId = strifeInstance.StrifeSpecibusId });
				_db.SaveChanges();
			}
			return RedirectToAction("Details", new { id = strifeInstance.StrifeSpecibusId});
		}
		
		public ActionResult Edit(int id)
		{
			StrifeSpecibus thisStrife = _db.StrifeSpecibi.FirstOrDefault(strifeInstance => strifeInstance.StrifeSpecibusId == id);
			return View(thisStrife);
		}
		
		[HttpPost]
		public ActionResult Edit(StrifeSpecibus strifeInstance)
		{
			_db.StrifeSpecibi.Update(strifeInstance);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Delete(int id)
		{
			StrifeSpecibus thisStrife = _db.StrifeSpecibi.FirstOrDefault(specibi => specibi.StrifeSpecibusId == id);
			return View(thisStrife);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			StrifeSpecibus thisStrife = _db.StrifeSpecibi.FirstOrDefault(specibi => specibi.StrifeSpecibusId == id);
			_db.StrifeSpecibi.Remove(thisStrife);
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