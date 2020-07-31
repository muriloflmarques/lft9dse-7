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
        private Student _student;

        public int Id { get; protected private set; }

        public string AddresLineOne
        {
            get { return _addresLineOne; }
            private set { _addresLineOne = value; }
        }

        public string AddresLineTwo
        {
            get { return _addresLineTwo; }
            private set { _addresLineTwo = value; }
        }

        public int? Number
        {
            get { return _number; }
            private set { _number = value; }
        }

        public string City
        {
            get { return _city; }
            private set { _city = value; }
        }

        public string CountyOrProvince
        {
            get { return _countyOrProvince; }
            private set { _countyOrProvince = value; }
        }

        public Country Country
        {
            get { return _country; }
            private set { _country = value; }
        }

        public int StudentId { get; protected private set; }

        public Student Student
        {
            get { return _student; }
            private set { _student = value; }
        }
    }
}