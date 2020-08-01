using SCM.Models;
using SCM_API.Models.Adreess;

namespace SCM_API.Models.Student
{
    public class StudentCreateViewModel
    {
        public StudentViewModel Student { get; set; }

        public AddressViewModel[] Addresses { get; set; }

        public ErrorViewModel Error { get; set; }
    }
}