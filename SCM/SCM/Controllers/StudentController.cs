using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Infra.CrossCutting.CustomException;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Infra.Data.Interface;
using Scm.Service.Interface;
using SCM.Models;
using SCM_API.Mapper;
using SCM_API.Models.Student;
using Smc.Infra.Data.Interface;
using System;
using System.Linq;

namespace SCM_API
{
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;

        public StudentController(IMapper mapper, IUnitOfWork unitOfWork,
            IStudentService studentService, IStudentRepository studentRepository)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

            this._studentService = studentService;
            this._studentRepository = studentRepository;
        }

        [HttpGet()]
        public ActionResult Index()
        {
            var studentIndexViewModel = this.SearchStudents(new StudentSearchViewModel());

            return View(studentIndexViewModel);
        }

        [HttpPost()]
        public ActionResult Index(StudentIndexViewModel studentIndexViewModel)
        {
            var returnStudentIndexViewModel = this.SearchStudents(studentIndexViewModel.StudentSearch);

            return View(returnStudentIndexViewModel);
        }

        private StudentIndexViewModel SearchStudents(StudentSearchViewModel studentSearchViewModel)
        {
            var studentSearchDto = _mapper.Map<StudentSearchDto>(studentSearchViewModel);

            var students = _studentService.SelectStudents(studentSearchDto);

            return new StudentIndexViewModel()
            {
                Students = students?.Select(st => { return st.MapToViewModel(); }).ToArray(),
                StudentSearch = studentSearchViewModel
            };
        }

        [HttpGet()]
        public ActionResult Create()
        {
            var studentCreateViewModel = new StudentCreateViewModel();

            return View(studentCreateViewModel);
        }

        [HttpPost()]
        public ActionResult Create(StudentCreateViewModel studentCreateViewModel)
        {
            try
            {
                var student = studentCreateViewModel.Student.MapToDomain();
                _studentRepository.Insert(student);
                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                studentCreateViewModel.Error = new ErrorViewModel(ex.Message);

                if (ex is DomainRulesException)
                    studentCreateViewModel.Error.SetAsDomainRulesException();

                return View(studentCreateViewModel);
            }
        }

        [HttpGet()]
        public ActionResult Edit(int id)
        {
            try
            {
                var dbSet = _studentRepository.AddDefaultIncludeIntoDbSet(_studentRepository.GetDbSet());

                var student = _studentRepository.SelectById(dbSet, id);

                //if student Null, then the better approach would be redirecting to ErrorPage
                if (student == null)
                    throw new BusinessLogicException($"Error while searching for Student with Id {id}");

                var studentViewModel = student.MapToViewModel();

                return View(studentViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel(ex.Message);

                if (ex is DomainRulesException)
                    ViewBag.Error.SetAsDomainRulesException();

                return View(new StudentViewModel());
            }
        }

        [HttpPost()]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            try
            {
                var dbSet = _studentRepository
                    .AddDefaultIncludeIntoDbSet(_studentRepository.GetDbSetAsNoTracking());

                var student = _studentRepository.SelectById(dbSet, studentViewModel.Id);

                //if student Null, then the better approach would be redirecting to ErrorPage
                if (student == null)
                    throw new BusinessLogicException($"Error while searching for Student with Id {studentViewModel.Id}");

                student.AlterBasicData(
                    firstName: studentViewModel.FirstName,
                    surname: studentViewModel.Surname,
                    dateOfBirth: studentViewModel.DateOfBirth,
                    gender: studentViewModel.Gender,
                    firstAddres: studentViewModel.FirstAddress,
                    secondAddres: studentViewModel.SecondAddress,
                    thirdAddres: studentViewModel.ThirdAddress);

                _studentRepository.Update(student);

                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel(ex.Message);

                if (ex is DomainRulesException)
                    ViewBag.Error.SetAsDomainRulesException();

                return View(studentViewModel);
            }
        }

        [HttpGet()]
        public ActionResult Delete(int id)
        {
            var dbSet = _studentRepository
                .AddDefaultIncludeIntoDbSet(_studentRepository.GetDbSetAsNoTracking());

            var student = _studentRepository.SelectById(dbSet, id);

            //if student Null, then the better approach would be redirecting to ErrorPage
            if (student != null)
            {
                _studentRepository.Delete(student);
                _unitOfWork.Commit();
            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult AddCourses(StudentViewModel studentViewModel)
        {

        }
    }
}