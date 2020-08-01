using Scm.Domain;
using SCM_API.Models.Adreess;

namespace SCM_API.Mapper
{
    public static class AddressMapper
    {
        public static AddressViewModel MapToViewModel(this Address address) 
        {
            return new AddressViewModel();
        }
    }
}