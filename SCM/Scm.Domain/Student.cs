using Scm.Infra.CrossCutting.CustomException;
using Scm.Infra.CrossCutting.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scm.Domain
{
    public class Student : BaseEntity
    {
        protected Student() { }

        public Student(string firstName, string surname, DateTime dateOfBirth, GenderEnum gender,
            string firstAddres, string secondAddres, string thirdAddres)
            : base()
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;

            this.FirstAddress = firstAddres;
            this.SecondAddress = secondAddres;
            this.ThirdAddress = thirdAddres;
        }

        private string _firstName;
        private string _surname;
        private DateTime _dateOfBirth;
        private string _firstAddress;
        private string _secnodAddress;
        private string _thirdAddress;

        public string FirstName
        {
            get { return _firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainRulesException("A name is needed when creating a new Student");

                if (value.Any(c => char.IsDigit(c)))
                    throw new DomainRulesException("The Student's name can not contain a number");

                if (value.Length > 30)
                    throw new DomainRulesException("The Student's name can not be longer than 30 characteres");

                if (value.Length < 3)
                    throw new DomainRulesException("The Student's name can not have less than 3 characteres");

                _firstName = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainRulesException("A surname is needed when creating a new Student");

                if (value.Any(c => char.IsDigit(c)))
                    throw new DomainRulesException("The Student's surname can not contain a number");

                if (value.Length > 120)
                    throw new DomainRulesException("The Student's surname can not be longer than 120 characteres");

                if (value.Length < 3)
                    throw new DomainRulesException("The Student's surname can not have less than 3 characteres");

                _surname = value;
            }
        }

        public GenderEnum Gender { get; private set; }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set
            {
                if (value.Year < 1900)
                    throw new DomainRulesException("Date of birth's year is marked to be greater than 1900");

                if (value > DateTime.Now)
                    throw new DomainRulesException("Date of birth can not be setted in the future");

                _dateOfBirth = value;
            }
        }

        public string FirstAddress
        {
            get { return _firstAddress; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainRulesException("The first address is needed when creating a new Student");

                if (value.Length > 200)
                    throw new DomainRulesException("The Student's first address can not be longer than 200 characteres");

                if (value.Length < 3)
                    throw new DomainRulesException("The Student's first address can not have less than 3 characteres");

                _firstAddress = value;
            }
        }

        public string SecondAddress
        {
            get { return _secnodAddress; }
            private set
            {
                if (value?.Length > 200)
                    throw new DomainRulesException("The Student's second address can not be longer than 200 characteres");

                if (value?.Length < 3)
                    throw new DomainRulesException("The Student's second address can not have less than 3 characteres");

                _secnodAddress = value;
            }
        }

        public string ThirdAddress
        {
            get { return _thirdAddress; }
            private set
            {
                if (value?.Length > 200)
                    throw new DomainRulesException("The Student's third address can not be longer than 200 characteres");

                if (value?.Length < 3)
                    throw new DomainRulesException("The Student's third address can not have less than 3 characteres");

                _thirdAddress = value;
            }
        }

        public ICollection<StudentCourse> StudentCourses { get; private set; } = new HashSet<StudentCourse>();

        public void AlterBasicData(string firstName, string surname, DateTime dateOfBirth, GenderEnum gender,
            string firstAddres, string secondAddres, string thirdAddres)
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;

            this.FirstAddress = firstAddres ?? this.FirstAddress;
            this.SecondAddress = secondAddres ?? this.SecondAddress;
            this.ThirdAddress = thirdAddres ?? this.ThirdAddress;
        }

        public void AddCourse(Course course)
        {
            if (course == null)
                throw new BusinessLogicException("A Course must be informed to enroll a Student");

            if (this.StudentCourses?.Count >= 5)
                throw new BusinessLogicException($"The Student {this.FirstName} have reached the maximum number of Courses to enroll");

            if(!course.CourseCanEnrollStudents())
                throw new DomainRulesException($"The Course {course.Name} have reached the maximum number of enrolled Students");

            var studentCourse = new StudentCourse(this, course);

            this.StudentCourses.Add(studentCourse);
        }

        public void RemoveCourse(Course course)
        {
            if (course == null)
                throw new BusinessLogicException("A Course must be informed to remove a Student");

            var studentCourse = this.StudentCourses.FirstOrDefault(stCo => stCo.Course.Id == course.Id);

            if (studentCourse != null)
                this.StudentCourses.Remove(studentCourse);

            //if (!course.StudentCourses.Any(stCo => stCo.Student.Id == this.Id))
            //    course.RemoveStudent(this);
        }
    }
}