using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AnatoknightStudios.BLL.Ops;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.UI.Controllers
{
    public class BlogApiController : ApiController
    {
        public List<Post> Get()
        {
            var ops = new BlogOperations();
            return ops.GetAllPosts();
        }

        public Post Get(int id)
        {
            var ops = new BlogOperations();
            return ops.GetPostById(id);
        }

        //    public HttpResponseMessage Post(int id)
        //    {
        //        var ops = new BlogOperations();
        //        ops.Delete(id);

        //        var response = Request.CreateResponse(HttpStatusCode.Created, newContact);

        //        string uri = Url.Link("DefaultApi", new { id = newContact.ContactID });
        //        response.Headers.Location = new Uri(uri);

        //        return response;
        //    }
        //}
    }
}
