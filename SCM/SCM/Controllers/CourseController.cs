using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Infra.Data.Interface;
using Scm.Service.Interface;
using SCM_API.Mapper;
using SCM_API.Models.Course;
using Smc.Infra.Data.Interface;
using System.Linq;

namespace SCM_API
{
    public class CourseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICourseService _courseService;
        private readonly ICourseRepository _courseRepository;

        public CourseController(IMapper mapper, IUnitOfWork unitOfWork,
            ICourseService courseService, ICourseRepository courseRepository)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;

            this._courseService = courseService;
            this._courseRepository = courseRepository;
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
            catch
            {
                return View();
            }
        }

        [HttpGet()]
        public ActionResult Edit(int id)
        {
            var dbSet = _courseRepository.AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSet());

            var course = _courseRepository.SelectById(dbSet, id);

            if (course == null)
            {
                //the better approach would be redirecting to ErrorPage
                return RedirectToAction(nameof(Index));
            }

            var viewMap = course.MapToViewModel();

            return View(viewMap);
        }

        [HttpPost()]
        public ActionResult Edit(CourseViewModel courseViewModel)
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

        [HttpGet()]
        public ActionResult Delete(int id)
        {
            var dbSet = _courseRepository
                .AddDefaultIncludeIntoDbSet(_courseRepository.GetDbSetAsNoTracking());

            var COURSE = _courseRepository.SelectById(dbSet, id);

            //if course Null, then the better approach would be redirecting to ErrorPage
            if (COURSE != null)
            {
                _courseRepository.Delete(COURSE);
                _unitOfWork.Commit();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}