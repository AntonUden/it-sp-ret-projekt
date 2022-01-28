using System.ComponentModel.DataAnnotations;

namespace Uppgifter_IdentityAndSession.Models
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }

		public string Name { get; set; }

		public double Price { get; set; }
	}
}
