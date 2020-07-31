namespace Scm.Domain
{
    //It doesn't need BaseEntity because the management of 
    //this table will probably be nonexistent
    public class Country
    {
        protected Country() { }

        public Country(string name)
        {
            this.Name = name;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
    }
}