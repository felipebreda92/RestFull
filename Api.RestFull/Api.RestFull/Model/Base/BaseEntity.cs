using System.Runtime.Serialization;

namespace Api.RestFull.Model.Base
{
    [DataContract]
    public class BaseEntity
    {
        public long Id { get; set; }
    }
}
