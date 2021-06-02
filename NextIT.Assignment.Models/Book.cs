using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NextIT.Assignment.Models
{
    public class Book
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        [JsonPropertyName("Author")]
        [Required]
        public string Author { get; set; }

        [JsonPropertyName("Borrowed")]
        public BorrowingPerson Borrowed { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}\nName: {Name}\nAuthor: {Author}\nBorrowed: \n\t{Borrowed}\n";
        }
    }
}
