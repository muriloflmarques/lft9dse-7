using Scm.Infra.CrossCutting.CustomException;
using Scm.Infra.CrossCutting.Helper;
using System;
using System.Collections.Generic;

namespace Scm.Domain
{
    public class Course : BaseEntity
    {
        protected Course() { }

        public Course(string name, string teacherName, DateTime startDate, DateTime endDate,
            int capacity) : base()
        {
            this.Name = name;
            this.TeacherName = teacherName;            
            this.EndDate = endDate;
            this.StartDate = startDate;
            this.Capacity = capacity;
        }

        private string _name;
        private string _teacherName;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _capacity;

        public string Name
        {
            get { return _name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainRulesException("A name is needed when creating a new Course");

                if (value.Length > 150)
                    throw new DomainRulesException("The Student's name can not be longer than 150 characteres");

                if (value.Length < 3)
                    throw new DomainRulesException("The Student's name can not have less than 3 characteres");

                _name = value; 
            }
        }

        public string TeacherName
        {
            get { return _teacherName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new DomainRulesException("A Teacher's name is needed when creating a new Course");

                if (value.Length > 150)
                    throw new DomainRulesException("The Teacher's name can not be longer than 150 characteres");

                if (value.Length < 3)
                    throw new DomainRulesException("The Teacher's name can not have less than 3 characteres");

                _teacherName = value;
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            private set
            {
                if (value.Year < 1900)
                    throw new DomainRulesException("The Course's start date is marked to be greater than 1900");

                //It's necessary to set EndDate before StartDate to assure the validation below
                if (value > this._endDate)
                    throw new DomainRulesException($"The Course's start date ({value.DefaultDateTimeFormat()}) can not be greater than end date ({this._endDate.DefaultDateTimeFormat()})");

                _startDate = value;
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            private set
            {
                if (value.Year < 1900)
                    throw new DomainRulesException("The Course's end date is marked to be greater than 1900");

                if (value < this._startDate)
                    throw new DomainRulesException($"The Course's end date ({value.DefaultDateTimeFormat()}) can not be less than start date ({this._startDate.DefaultDateTimeFormat()})");

                _endDate = value; 
            }
        }

        public string Code { get; private set; }
    
        public int Capacity
        {
            get { return _capacity; }
            private set 
            {
                if(value <= 0)
                    throw new DomainRulesException($"A Course's capacity can not be negative nor iqual to zero");
                
                if (value < this._capacity && value < this.StudentCourses?.Count)
                    throw new DomainRulesException($"It's impossibel to reduce Course's capacity to {value} because this Course already has {this.StudentCourses?.Count} Students enrolled");

                _capacity = value;
            }
        }

        public ICollection<StudentCourse> StudentCourses { get; private set; } = new HashSet<StudentCourse>();

        public void AlterBasicData(string name, string teacherName, DateTime startDate, DateTime endDate, int capacity)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.EndDate = endDate; 
            this.StartDate = startDate;            
            this.Capacity = capacity;
        }
    }
}