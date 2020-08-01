using SCM_API.Models.Adreess;
using SCM_API.Models.Course;
using System.ComponentModel;

namespace SCM_API.Models.Student
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        public string Surname { get; set; }

        [DisplayName("Date of Birth")]
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }

        public AddressViewModel[] Addresses { get; set; }
        public CourseViewModel[] Courses { get; set; }
    }
}