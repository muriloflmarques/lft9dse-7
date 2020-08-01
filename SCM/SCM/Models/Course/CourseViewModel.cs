namespace SCM_API.Models.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public string TeacherName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Code { get; set; }
    }
}