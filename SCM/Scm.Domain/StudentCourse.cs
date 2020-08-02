namespace Scm.Domain
{
    public class StudentCourse
    {
        protected StudentCourse() { }

        public StudentCourse(Student student, Course course)
        {
            this.Student = student;
            this.Course = course;
        }

        public int StudentId { get; protected set; }
        public Student Student { get; protected set; }
        public int CourseId { get; protected set; }
        public Course Course { get; protected set; }
    }
}