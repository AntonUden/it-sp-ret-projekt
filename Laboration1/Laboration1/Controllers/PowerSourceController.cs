using Laboration1.Data;
using Laboration1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboration1.Controllers
{
	public class PowerSourceController : Controller
	{
		private ItemDBContext db;

		public PowerSourceController(ItemDBContext context)
		{
			this.db = context;
		}

		public IActionResult Index()
		{
			return View(db.PowerSources.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(PowerSource powerSource)
		{
			db.PowerSources.Add(powerSource);

			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			PowerSource powerSource = db.PowerSources.FirstOrDefault(ps => ps.PowerSourceId == id);

			return View(powerSource);
		}

		[HttpPost]
		public IActionResult Edit(PowerSource powerSource)
		{
			db.Entry<PowerSource>(powerSource).State = EntityState.Modified;

			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			db.Entry<PowerSource>(new PowerSource() { PowerSourceId = id }).State = EntityState.Deleted;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
