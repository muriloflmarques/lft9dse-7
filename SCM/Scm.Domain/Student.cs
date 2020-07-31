using Scm.Infra.CrossCutting.Enum;
using System;
using System.Collections.Generic;

namespace Scm.Domain
{
    public class Student : BaseEntity
    {
        protected Student() { }

        public Student(string firstName, string surname, DateTime dateOfBirth)
            : base()
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
        }

        private string _firstName;
        private string _surname;
        private DateTime _dateOfBirth;

        public string FirstName
        {
            get { return _firstName; }
            private set { _firstName = value; }
        }

        public string Surname
        {
            get { return _surname; }
            private set { _surname = value; }
        }

        public GenderEnum Gender { get; private set; }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set { _dateOfBirth = value; }
        }

        public ICollection<Address> Addresses { get; private set; } = new HashSet<Address>();
        public ICollection<StudentCourse> StudentCourses { get; private set; } = new HashSet<StudentCourse>();
    }
}