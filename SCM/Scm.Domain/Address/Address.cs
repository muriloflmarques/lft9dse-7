namespace Scm.Domain
{
    public class Address
    {
        protected Address() { }

        public Address(string addresLineOne, string addresLineTow, int? number, string city,
            string countyOrProvince, Country country)
        {
            this.AddresLineOne = addresLineOne;
            this.AddresLineTwo = addresLineTow;
            this.Number = number;
            this.City = city;
            this.CountyOrProvince = countyOrProvince;
            this.Country = country;
        }

        private string _addresLineOne;
        private string _addresLineTwo;
        private int? _number;
        private string _city;
        private string _countyOrProvince;
        private Country _country;

        public int Id { get; protected set; }

        public string AddresLineOne
        {
            get { return _addresLineOne; }
            set { _addresLineOne = value; }
        }

        public string AddresLineTwo
        {
            get { return _addresLineTwo; }
            set { _addresLineTwo = value; }
        }

        public int? Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string CountyOrProvince
        {
            get { return _countyOrProvince; }
            set { _countyOrProvince = value; }
        }

        public Country Country
        {
            get { return _country; }
            set { _country = value; }
        }
    }
}