using Microsoft.AspNetCore.Mvc;
using Scm.Service.Interface;
using SCM_API.Models.Student;

namespace SCM_API
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var viewModel = new StudentIndexViewModel();

            return View(viewModel);
        }

        //// GET: StudentController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: StudentController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: StudentController/Create
        //[HttpPost]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: StudentController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: StudentController/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: StudentController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: StudentController/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}