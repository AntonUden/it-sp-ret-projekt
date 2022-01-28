using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboration1.Models
{
	public class Item
	{
		public int ItemId { get; set; }

		public string name { get; set; }

		public string Description { get; set; }

		public int PowerSourceId { get; set; }

		public PowerSource PowerSource { get; set; }

		public int CategoryId { get; set; }

		public Category Category { get; set; }

		public string ThumbnailHash { get; set; }
	}
}