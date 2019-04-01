using Api.RestFull.Model.Base;
using System;

namespace Api.RestFull.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LauchDate { get; set; }
    }
}
