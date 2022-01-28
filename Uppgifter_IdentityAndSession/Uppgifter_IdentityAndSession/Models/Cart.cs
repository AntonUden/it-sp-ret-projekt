using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgifter_IdentityAndSession.Models
{
	public class Cart
	{
		public Cart()
		{
			this.Items = new List<CartItem>();
		}

		public List<CartItem> Items { get; set; }
	}
}
