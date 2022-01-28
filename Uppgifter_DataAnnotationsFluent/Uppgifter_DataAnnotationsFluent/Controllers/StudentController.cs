using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uppgifter_DataAnnotationsFluent.Data;

namespace Uppgifter_DataAnnotationsFluent.Controllers
{
	public class StudentController : Controller
	{
		private StudentDbContext db;

		public StudentController(StudentDbContext context)
		{
			this.db = context;
		}

		public IActionResult Index()
		{
			return View(db.Students.ToList());
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Models.Student student)
		{
			db.Students.Add(student);

			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
