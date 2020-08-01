using SCM.Models;

namespace SCM_API.Models.Student
{
    public class StudentCreateViewModel
    {
        public StudentViewModel Student { get; set; }

        public ErrorViewModel Error { get; set; }
    }
}