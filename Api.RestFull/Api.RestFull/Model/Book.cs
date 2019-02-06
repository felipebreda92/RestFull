using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.RestFull.Model
{
    public class Book
    {
        //[Key]
        //[Column("id")] //Mapping Database Column Name
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LauchDate { get; set; }


    }
}
