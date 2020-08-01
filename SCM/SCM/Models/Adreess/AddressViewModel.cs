namespace SCM_API.Models.Adreess
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        public string AddresLineOne { get; set; }
        public string AddresLineTwo { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string CountyOrProvince { get; set; }
        public string Country { get; set; }
    }
}