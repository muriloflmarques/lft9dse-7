using System.ComponentModel;

namespace SCM_API.Models.Adreess
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        [DisplayName("Addres Line One")]
        public string AddresLineOne { get; set; }

        [DisplayName("Addres Line Two")]
        public string AddresLineTwo { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        
        [DisplayName("County / Province")]
        public string CountyOrProvince { get; set; }

        public int CountryId { get; set; }
        public string Country { get; set; }
    }
}