using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Service.Interface;
using SCM_API.Mapper;
using SCM_API.Models.Student;
using Smc.Infra.Data.Interface;
using System.Linq;

namespace SCM_API
{
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IStudentService _studentService;

        public StudentController(IMapper mapper, IUnitOfWork unitOfWork,
            IStudentService studentService)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

            this._studentService = studentService;
        }

        // GET: StudentController
        [HttpGet()]
        public ActionResult Index()
        {
            var students = _studentService.SelectStudents(new SearchStudentDto());

            var studentIndexViewModel = new StudentIndexViewModel()
            {
                Students = students?.Select(st => { return st.MapToViewModel(); }).ToArray()
            };

            return View(studentIndexViewModel);
        }

        [HttpPost]
        public ActionResult Search(SearchStudentViewModel searchStudentViewModel)
        {
            var searchStudentDto = _mapper.Map<SearchStudentDto>(searchStudentViewModel);

            var students = _studentService.SelectStudents(searchStudentDto);

            var viewModel = new StudentIndexViewModel()
            {
                Students = students?.Select(st => { return st.MapToViewModel(); }).ToArray()
            };

            return View(viewModel);
        }


        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

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