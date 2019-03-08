using System;
using System.Runtime.Serialization;

namespace Api.RestFull.Data.VO
{
    //[DataContract]
    public class BookVO
    {
        //[DataMember(Order = 1, Name = "Codigo")]
        public long Id { get; set; }

        //[DataMember(Order = 2)]
        public string Title { get; set; }

        //[DataMember(Order = 3)]
        public string Author { get; set; }

        //[DataMember(Order = 5, Name = "Codigo")]
        public decimal Price { get; set; }

        //[DataMember(Order = 4, Name = "Codigo")]
        public DateTime LauchDate { get; set; }
    }
}
