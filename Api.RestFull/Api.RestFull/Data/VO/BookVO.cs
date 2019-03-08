using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Api.RestFull.Data.VO
{
    //[DataContract]
    public class BookVO
    {
        //[DataMember(Order = 1, Name = "Codigo")]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LauchDate { get; set; }
    }
}
