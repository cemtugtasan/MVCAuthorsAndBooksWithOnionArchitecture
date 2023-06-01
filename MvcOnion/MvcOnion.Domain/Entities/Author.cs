using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcOnion.Domain.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Navigation
        public virtual ICollection<Book> Books { get; set; }
       
        public Author()
        {
            this.Books = new HashSet<Book>();
        }
    }
}
