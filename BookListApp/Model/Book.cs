using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListApp.Model
{
    public class Book
    {
        [Key]   // Auto-generate a new key(Id) 
        public int Id { get; set; }
        
        [Required] // To make sure that a user provide data
        public string Title { get; set; }
        [Required] // To make sure that a user provide data
        public string Author { get; set; }
        [Required] // To make sure that a user provide data
        public int ISBN { get; set; }
    }
}
