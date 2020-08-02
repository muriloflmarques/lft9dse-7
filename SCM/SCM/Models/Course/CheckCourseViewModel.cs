namespace SCM_API.Models.Course
{
    public class CheckCourseViewModel
    {
        public CourseViewModel[] AvailableCourses { get; set; } = new CourseViewModel[] { };
        public CourseViewModel[] EnrolledCourses { get; set; } = new CourseViewModel[] { };
    }
}