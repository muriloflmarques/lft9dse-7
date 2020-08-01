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
            private set { _name = value; }
        }

        public string TeacherName
        {
            get { return _teacherName; }
            private set { _teacherName = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            private set { _startDate = value; }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            private set { _endDate = value; }
        }

        public string Code { get; private set; }
        public int Capacity { get; private set; }
        public ICollection<StudentCourse> StudentCourses { get; private set; } = new HashSet<StudentCourse>();

        public void AlterBasicData(string name, string teacherName, DateTime startDate, DateTime endDate, int capacity)
        {
            this.Name = name;
            this.TeacherName = teacherName;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Capacity = capacity;
        }
    }
}