using System.Collections.Generic;

namespace Api.RestFull.Data.Converter
{
    public interface IParser<Origin, Destiny>
    {
        Destiny Parse(Origin origin);
        List<Destiny> ParseList(List<Origin> origins);
    }
}
