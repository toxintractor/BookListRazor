using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Boek naam")]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public String Author { get; set; }

    }
}
