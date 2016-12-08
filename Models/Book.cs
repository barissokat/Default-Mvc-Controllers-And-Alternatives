using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DefaultMvcControllersAndAlternatives.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Book Name")]
        public string Name { get; set; }
        public long ISBN { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        [DisplayName("Publication Date")]
        public int PublicationDate { get; set; }
        public string Price { get; set; }
        [DisplayName("Reduced Price")]
        public string ReducedPrice { get; set; }
        public virtual Category Category { get; set; }
    }
}