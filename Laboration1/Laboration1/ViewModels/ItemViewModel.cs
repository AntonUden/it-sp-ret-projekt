using Laboration1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboration1.ViewModels
{
	public class ItemViewModel
	{
		public ItemViewModel(List<PowerSource> powerSources, List<Category> categories)
		{
			this.PowerSources = new SelectList(powerSources, "PowerSourceId", "Name");
			this.Categories = new SelectList(categories, "CategoryId", "Name");
		}

		public ItemViewModel()
		{

		}

		public int ItemId { get; set; }

		public string name { get; set; }

		public string Description { get; set; }

		public int PowerSourceId { get; set; }

		public int CategoryId { get; set; }

		public string ThumbnailHash { get; set; }

		public SelectList Categories { get; set; }

		public SelectList PowerSources { get; set; }
	}
}