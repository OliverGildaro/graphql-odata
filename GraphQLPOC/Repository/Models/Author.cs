using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Author
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
