namespace Scm.Domain
{
    public class StudentCourse
    {
        public int StudentId { get; protected set; }
        public Student Student { get; protected set; }
        public int CourseId { get; protected set; }
        public Course Course { get; protected set; }
    }
}