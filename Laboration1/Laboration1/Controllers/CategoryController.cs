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
	public class CategoryController : Controller
	{
		private ItemDBContext db;

		public CategoryController(ItemDBContext context)
		{
			this.db = context;
		}

		public IActionResult Index()
		{
			return View(db.Categories.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category category)
		{
			db.Categories.Add(category);

			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			Category category = db.Categories.FirstOrDefault(c => c.CategoryId == id);

			return View(category);
		}

		[HttpPost]
		public IActionResult Edit(Category category)
		{
			db.Entry<Category>(category).State = EntityState.Modified;

			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			db.Entry<Category>(new Category() { CategoryId = id }).State = EntityState.Deleted;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
