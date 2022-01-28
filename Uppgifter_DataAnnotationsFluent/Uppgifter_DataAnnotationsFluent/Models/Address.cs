using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgifter_DataAnnotationsFluent.Models
{
	public class Address
	{
		[Key]
		public int AddressId { get; set; }

		[Required]
		public string Street { get; set; }

		[Required]
		public string City { get; set; }
		
		public int StudentId { get; set; }

		public Student Student { get; set; }
	}
}
