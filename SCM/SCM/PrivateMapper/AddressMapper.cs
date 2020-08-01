using Scm.Domain;
using SCM_API.Models.Adreess;

namespace SCM_API.Mapper
{
    public static class AddressMapper
    {
        public static AddressViewModel MapToViewModel(this Address address) 
        {
            return new AddressViewModel()
            {
                Id = address.Id,

                AddresLineOne = address.AddresLineOne,
                AddresLineTwo = address.AddresLineTwo,
                Number=address.Number?.ToString() ?? "n/n",
                City = address.City,
                CountyOrProvince = address.CountyOrProvince,

                CountryId = address.Country.Id,
                Country = address.Country.Name
            };
        }
    }
}