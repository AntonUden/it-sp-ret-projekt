using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgifter_DataAnnotationsFluent.Models
{
	public class Course
	{
		[Key]
		public int CourseId { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
