using Laboration1.Data;
using Laboration1.Models;
using Laboration1.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Laboration1.Controllers
{
	public class ItemController : Controller
	{
		private ItemDBContext db;

		public ItemController(ItemDBContext context)
		{
			this.db = context;
		}

		public IActionResult Index(string query, int page = 1)
		{
			if (page <= 0)
			{
				page = 1;
			}

			int count;
			List<Item> items;

			if (query == null)
			{
				count = db.Items.Count();
				items = db.Items.Include(item => item.Category).Include(item => item.PowerSource).Skip((page - 1) * 5).Take(5).OrderBy(i => i.ItemId).ToList();
			}
			else
			{
				query = query.ToLower();
				count = db.Items.Include(item => item.Category).Include(item => item.PowerSource).Where(i => i.name.ToLower().Contains(query) || i.Category.Name.ToLower().Contains(query) || i.PowerSource.Name.ToLower().Contains(query)).Count();
				items = db.Items.Include(item => item.Category).Include(item => item.PowerSource).Where(i => i.name.ToLower().Contains(query) || i.Category.Name.ToLower().Contains(query) || i.PowerSource.Name.ToLower().Contains(query)).Skip((page - 1) * 5).Take(5).OrderBy(i => i.ItemId).ToList();
			}

			return View(new ItemIndexViewModel() { Items = items, Page = page, TotalItems = count });
		}

		[HttpGet]
		public IActionResult Create()
		{
			ItemViewModel model = new ItemViewModel(db.PowerSources.ToList(), db.Categories.ToList());
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(ItemViewModel item)
		{
			db.Items.Add(new Item()
			{
				name = item.name,
				Description = item.Description,
				CategoryId = item.CategoryId,
				PowerSourceId = item.PowerSourceId,
				ThumbnailHash = item.ThumbnailHash
			});

			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			Item item = db.Items.Include(i => i.Category).Include(i => i.PowerSource).FirstOrDefault(i => i.ItemId == id);

			return View(item);
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			db.Entry<Item>(new Item() { ItemId = id }).State = EntityState.Deleted;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			ItemViewModel model = new ItemViewModel(db.PowerSources.ToList(), db.Categories.ToList());
			Item item = db.Items.FirstOrDefault(i => i.ItemId == id);

			model.ItemId = item.ItemId;
			model.name = item.name;
			model.Description = item.Description;
			model.CategoryId = item.CategoryId;
			model.PowerSourceId = item.PowerSourceId;
			model.ThumbnailHash = item.ThumbnailHash;

			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(ItemViewModel itemModel)
		{
			Item item = new Item() { ItemId = itemModel.ItemId, CategoryId = itemModel.CategoryId, PowerSourceId = itemModel.PowerSourceId, Description = itemModel.Description, name = itemModel.name, ThumbnailHash = itemModel.ThumbnailHash };

			db.Entry<Item>(item).State = EntityState.Modified;

			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
