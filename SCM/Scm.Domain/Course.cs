using System;
using System.Collections.Generic;
using System.Text;

namespace Scm.Domain
{
    public class Course : BaseEntity
    {
        protected Course() { }

        public Course(string name, string teacherName, DateTime startDate, DateTime endDate,
            int capacity): base()
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Capacity = capacity;
        }

        private string _name;
        private string _teacherName;
        private DateTime _startDate;
        private DateTime _endDate;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string TeacherName
        {
            get { return _teacherName; }
            set { _teacherName = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }

        public string Code { get; set; }
        public int Capacity { get; set; }
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}