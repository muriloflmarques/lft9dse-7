using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Infra.CrossCutting.CustomException;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Infra.Data.Interface;
using Scm.Service.Interface;
using SCM.Models;
using SCM_API.Mapper;
using SCM_API.Models.Course;
using Smc.Infra.Data.Interface;
using System;
using System.Linq;

namespace SCM_API
{
    public class CourseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICourseService _courseService;
        private readonly ICourseRepository _courseRepository;

        private readonly IStudentService _studentService;
        private readonly IStudentRepository _studentRepository;

        public CourseController(IMapper mapper, IUnitOfWork unitOfWork,
            ICourseService courseService, ICourseRepository courseRepository,
            IStudentService studentService, IStudentRepository studentRepository)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

            this._courseService = courseService;
            this._courseRepository = courseRepository;

            this._studentService = studentService;
            this._studentRepository = studentRepository;
        }

        [HttpGet()]
        public ActionResult Index()
        {
            var courseIndexViewModel = this.SearchCourses(new CourseSearchViewModel());

            return View(courseIndexViewModel);
        }

        [HttpPost()]
        public ActionResult Index(CourseIndexViewModel courseIndexViewModel)
        {
            var returnCourseIndexViewModel = this.SearchCourses(courseIndexViewModel.CourseSearch);

            return View(returnCourseIndexViewModel);
        }

        private CourseIndexViewModel SearchCourses(CourseSearchViewModel courseSearchViewModel)
        {
            var courseSearchDto = _mapper.Map<CourseSearchDto>(courseSearchViewModel);

            var courses = _courseService.SelectCourses(courseSearchDto);

            return new CourseIndexViewModel()
            {
                Courses = courses?.Select(co => { return co.MapToViewModel(); }).ToArray(),
                CourseSearch = courseSearchViewModel
            };
        }

        [HttpGet()]
        public ActionResult Create()
        {
            var courseCreateViewModel = new CourseCreateViewModel();

            return View(courseCreateViewModel);
        }

        [HttpPost()]
        public ActionResult Create(CourseCreateViewModel courseCreateViewModel)
        {
            try
            {
                var course = courseCreateViewModel.Course.MapToDomain();
                _courseRepository.Insert(course);
                _unitOfWork.Commit();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                courseCreateViewModel.Error = new ErrorViewModel(ex.Message);

                if (ex is DomainRulesException)
                    courseCreateViewModel.Error.SetAsDomainRulesException();

                return View(courseCreateViewModel);
            }
        }

        [HttpGet()]
        public ActionResult Edit(int id)
        {
            try
            {
                var dbSet = _courseRepository.AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSet());

                var course = _courseRepository.SelectById(dbSet, id);

                if (course == null)
                {
                    //the better approach would be redirecting to ErrorPage
                    return RedirectToAction(nameof(Index));
                }

                var courseEditViewModel = course.MapToViewModel();

                return View(courseEditViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel(ex.Message);

                if (ex is DomainRulesException)
                    ViewBag.Error.SetAsDomainRulesException();

                return View(new CourseViewModel());
            }
        }

        [HttpPost()]
        public ActionResult Edit(CourseViewModel courseViewModel)
        {
            try
            {
                var dbSet = _courseRepository
                    .AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSetAsNoTracking());

                var course = _courseRepository.SelectById(dbSet, courseViewModel.Id);

                //if course Null, then the better approach would be redirecting to ErrorPage
                if (course != null)
                {
                    course.AlterBasicData(
                        name: courseViewModel.Name,
                        teacherName: courseViewModel.TeacherName,
                        startDate: courseViewModel.StartDate,
                        endDate: courseViewModel.EndDate,
                        capacity: courseViewModel.Capacity);

                    _courseRepository.Update(course);

                    _unitOfWork.Commit();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = new ErrorViewModel(ex.Message);

                if (ex is DomainRulesException)
                    ViewBag.Error.SetAsDomainRulesException();

                return View(courseViewModel);
            }
        }

        [HttpGet()]
        public ActionResult Delete(int id)
        {
            var dbSet = _courseRepository
                .AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSetAsNoTracking());

            var course = _courseRepository.SelectById(dbSet, id);

            //if course Null, then the better approach would be redirecting to ErrorPage
            if (course != null)
            {
                _courseRepository.Delete(course);
                _unitOfWork.Commit();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet()]
        public ActionResult CheckCourse(int idStudent)
        {
            var checkCourseViewModel = new CheckCourseViewModel();

            try
            {
                if (TempData["IncludingErrorMessage"] != null)
                    ViewBag.IncludingErrorMessage = TempData["IncludingErrorMessage"].ToString();
             
                if (TempData["RemovingErrorMessage"] != null)
                    ViewBag.RemovingErrorMessage = TempData["RemovingErrorMessage"].ToString();

                var dbSet = _studentRepository
                        .AddDefaultIncludeIntoDbSet(_studentRepository.GetDbSetAsNoTracking());

                var student = _studentRepository.SelectById(dbSet, idStudent);

                //if Null, then the better approach would be redirecting to ErrorPage
                if (student == null)
                    return RedirectToAction(nameof(Index));

                ViewBag.Student = student;

                checkCourseViewModel.AvailableCourses = _courseService.SelectStudentsAvailableCourses(idStudent)
                    .Select(co => { return co.MapToViewModel(); }).ToArray();

                checkCourseViewModel.EnrolledCourses = _courseService.SelectStudentsEnrolledCoursesTo(idStudent)
                    .Select(co => { return co.MapToViewModel(); }).ToArray();

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(checkCourseViewModel);
        }

        [HttpGet()]
        public ActionResult Include(int idStudent, int idCourse)
        {
            try
            {
                _studentService.IncludeCourseInStudent(idStudent: idStudent, idCourse: idCourse);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                TempData["IncludingErrorMessage"] = ex.Message;
            }

            return RedirectToAction("CheckCourse", new { idStudent });
        }

        [HttpGet()]
        public ActionResult Remove(int idStudent, int idCourse)
        {
            try
            {
                _studentService.RemoveCourseFromStudent(idStudent: idStudent, idCourse: idCourse);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                TempData["RemovingErrorMessage"] = ex.Message;
            }

            return RedirectToAction("CheckCourse", new { idStudent });
        }
    }
}