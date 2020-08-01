using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public string Name { get; private set; }
        public ICollection<Address> Addresses { get; protected set; }

        public void SetId(int Id) => this.Id = Id;
    }
}