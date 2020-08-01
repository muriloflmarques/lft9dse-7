﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Scm.Infra.CrossCutting.DTOs;
using Scm.Infra.Data.Interface;
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
            var studentIndexViewModel = this.SearchStudents(new SearchStudentViewModel());

            return View(studentIndexViewModel);
        }

        [HttpPost()]
        public ActionResult Index(StudentIndexViewModel studentIndexViewModel)
        {
            var searchStudentViewModel = this.SearchStudents(studentIndexViewModel.SearchStudent);

            return View(searchStudentViewModel);
        }

        private StudentIndexViewModel SearchStudents(SearchStudentViewModel searchStudentViewModel)
        {
            var searchStudentDto = _mapper.Map<SearchStudentDto>(searchStudentViewModel);

            var students = _studentService.SelectStudents(searchStudentDto);

            return new StudentIndexViewModel()
            {
                Students = students?.Select(st => { return st.MapToViewModel(); }).ToArray(),
                SearchStudent = searchStudentViewModel
            };
        }

        [HttpGet()]
        public ActionResult Create()
        {
            var viewData = new StudentCreateViewModel();

            return View(viewData);
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
            catch
            {
                return View();
            }
        }

        [HttpGet()]
        public ActionResult Edit(int id)
        {
            var dbSet = _studentRepository.AddDefaultIncludeIntoDbSet(_studentRepository.GetDbSet());

            var student = _studentRepository.SelectById(dbSet, id);

            if (student == null)
            {
                //the better approach would be redirecting to ErrorPage
                return RedirectToAction(nameof(Index));
            }

            var viewMap = student.MapToViewModel();

            return View(viewMap);
        }

        [HttpPost()]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            var dbSet = _studentRepository
                .AddDefaultIncludeIntoDbSet(_studentRepository.GetDbSetAsNoTracking());

            var student = _studentRepository.SelectById(dbSet, studentViewModel.Id);

            //if student Null, then the better approach would be redirecting to ErrorPage
            if (student != null)
            {
                student.AlterBasicData(
                    firstName: studentViewModel.FirstName,
                    surname: studentViewModel.Surname,
                    dateOfBirth: studentViewModel.DateOfBirth,
                    gender: studentViewModel.Gender);

                _studentRepository.Update(student);

                _unitOfWork.Commit();
            }

            return RedirectToAction(nameof(Index));
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
    }
}