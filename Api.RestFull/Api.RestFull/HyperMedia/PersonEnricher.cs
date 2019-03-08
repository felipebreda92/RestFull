using System.Threading.Tasks;
using Api.RestFull.Data.Converter;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;

namespace Api.RestFull.HyperMedia
{
    public class PersonEnricher : ObjectContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/person";
            var url = new { controller = path, id = content.Id };

            content.Links.Add(new HyperMediaLink() {
                    Action = HttpActionVerb.GET,
                    Href = urlHelper.Link("DefaultApi", url),
                    Rel = RelationType.self,
                    Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DefaultApi", url),
                Rel = RelationType.self,
                Type = "int"
            });

            return null;
        }
    }
}
