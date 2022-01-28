using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Uppgifter_DataAnnotationsFluent.Models
{
	public class Enrollment
	{
		[Key]
		public int EnrollmentId { get; set; }

		public int StudentId { get; set; }

		public Student Student { get; set; }

		public int CourseId { get; set; }

		public Course Course { get; set; }

		[Range(1, 5)]
		public int Grade { get; set; }
	}
}
