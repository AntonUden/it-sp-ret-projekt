using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgifter_IdentityAndSession.Data;

namespace Uppgifter_IdentityAndSession.Controllers
{
	public class ProductController : Controller
	{
		private ProductDbContext db;

		public ProductController(ProductDbContext context)
		{
			this.db = context;
		}

		public IActionResult Index()
		{
			return View(db.Products.ToList());
		}
	}
}
