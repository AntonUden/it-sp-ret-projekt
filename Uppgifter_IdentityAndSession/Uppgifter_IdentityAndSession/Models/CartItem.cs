using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgifter_IdentityAndSession.Models
{
	public class CartItem
	{
		public int ProductId { get; set; }

		public int Qty { get; set; }

		public double ItemPrice { get; set; }

		public string Name { get; set; }
	}
}
