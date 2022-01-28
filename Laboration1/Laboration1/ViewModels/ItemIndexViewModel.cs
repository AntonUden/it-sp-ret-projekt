using Laboration1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboration1.ViewModels
{
	public class ItemIndexViewModel
	{
		public List<Item> Items { get; set; }

		public int Page { get; set; }

		public int TotalItems { get; set; }
	}
}