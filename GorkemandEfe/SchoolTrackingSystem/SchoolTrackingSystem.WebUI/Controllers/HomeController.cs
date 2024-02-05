//Görkem Özer

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTrackingSystem.BusinessLayer.Concrete;
using SchoolTrackingSystem.DataAccessLayer.DataContext;
using SchoolTrackingSystem.EntityLayer.Model;
using SchoolTrackingSystem.WebUI.Models;
using System.Diagnostics;

namespace SchoolTrackingSystem.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private DbContext context = new SchoolTrackingDatabaseModelContext();
		private UnitOfWork unitOfWork;
		public HomeController()
		{
			unitOfWork = new(context);
		}
		[Route("sinif-ogrenci-listesi")]
		[Route("")]
		public async Task<IActionResult> Index()
		{
			var model = await unitOfWork.studentsEntityRepositoryBase.GetAllAsync();
			return View(model);
		}

		[Route("sinif-ogrenci-ekle")]
		public IActionResult Create()
		{
			return View();
		}

		[Route("sinif-ogrenci-ekle")]
		[HttpPost]
		public async Task<IActionResult> Create(Students students)
		{
			if (ModelState.IsValid)
			{
				await unitOfWork.studentsEntityRepositoryBase.AddAsync(students);
				await unitOfWork.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(students);
		}
		[Route("sinif-ogrenci-guncelle/{ID}")]
		public async Task<IActionResult> Edit(int ID)
		{
			var model = await unitOfWork.studentsEntityRepositoryBase.GetAsync(x => x.ID == ID);
			if (model == null)
				return RedirectToAction(nameof(Index));
			return View(model);
		}

        [Route("sinif-ogrenci-guncelle/{ID}")]
		[HttpPost]
		public async Task<IActionResult> Edit(int ID, Students students)
		{
			var model = await unitOfWork.studentsEntityRepositoryBase.GetAsync(x => x.ID == ID);
			if (ModelState.IsValid)
			{
				model.ID = students.ID;
				model.SchoolNumber = students.SchoolNumber;
				model.PhoneNumber = students.PhoneNumber;
				model.MotherNumber = students.MotherNumber;
				model.NameSurname=students.NameSurname;
				model.Classroom = students.Classroom;
				model.IsActive = students.IsActive;
				model.FatherNumber = students.FatherNumber;
				model.Email = students.Email;
				await unitOfWork.studentsEntityRepositoryBase.UpdateAsync(model);
				await unitOfWork.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
    }
}
