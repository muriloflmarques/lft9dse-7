﻿using Scm.Infra.CrossCutting.CustomException;
using Scm.Infra.CrossCutting.Enum;
using System;
using System.Collections.Generic;

namespace Scm.Domain
{
    public class Student : BaseEntity
    {
        protected Student() { }

        public Student(string firstName, string surname, DateTime dateOfBirth, GenderEnum gender)
            : base()
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
        }

        private string _firstName;
        private string _surname;
        private DateTime _dateOfBirth;

        public string FirstName
        {
            get { return _firstName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainRulesException("A name is needed when creating a new Task");

                if (value.Length > 30)
                    throw new DomainRulesException("The Student's name can not be longer than 30 characteres");

                if (value.Length < 3)
                    throw new DomainRulesException("The Student's name can not be shorter than 3 characteres");
                
                _firstName = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainRulesException("A name is needed when creating a new Task");

                if (value.Length > 120)
                    throw new DomainRulesException("The Student's name can not be longer than 120 characteres");

                if (value.Length < 3)
                    throw new DomainRulesException("The Student's name can not be shorter than 3 characteres");
               
                _surname = value; 
            }
        }

        public GenderEnum Gender { get; private set; }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            private set
            {
                if (value > DateTime.Now)
                    throw new DomainRulesException("Date of birth can not be setted in the future");

                _dateOfBirth = value; 
            }
        }

        public ICollection<Address> Addresses { get; private set; } = new HashSet<Address>();
        public ICollection<StudentCourse> StudentCourses { get; private set; } = new HashSet<StudentCourse>();

        public void AlterBasicData(string firstName, string surname, DateTime dateOfBirth, GenderEnum gender)
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
        }
    }
}