using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
