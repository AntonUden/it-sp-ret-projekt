using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgifter_IdentityAndSession.Code;
using Uppgifter_IdentityAndSession.Data;
using Uppgifter_IdentityAndSession.Models;

namespace Uppgifter_IdentityAndSession.Controllers
{
	public class CartController : Controller
	{
		private ProductDbContext db;
		private IHttpContextAccessor httpContext;

		public CartController(ProductDbContext db, IHttpContextAccessor httpContext)
		{
			this.db = db;
			this.httpContext = httpContext;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Add(int id, string returnurl)
		{
			var product = db.Products.FirstOrDefault(p => p.ProductId == id);
			if (product != null)
			{
				Cart cart = httpContext.HttpContext.Session.Get<Cart>(Utils.CART_KEY);

				if (cart == null)
				{
					cart = new Cart();	
				}

				var duplicate = cart.Items.FirstOrDefault(i => i.ProductId == product.ProductId);

				if (duplicate == null)
				{
					cart.Items.Add(new CartItem() { ProductId = product.ProductId, Name = product.Name, ItemPrice = product.Price, Qty = 1 });
				}
				else
				{
					duplicate.Qty++;
				}

				httpContext.HttpContext.Session.Set(Utils.CART_KEY, cart);
			}

			return Redirect(returnurl);
		}
	}
}
