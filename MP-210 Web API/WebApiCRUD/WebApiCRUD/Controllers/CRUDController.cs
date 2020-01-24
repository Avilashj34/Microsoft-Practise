using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiCRUD.Controllers
{
    public class CRUDController : ApiController
    {
        [Route("api/example/crud")]
        public IEnumerable<string> Get()
        {
            return new string[] { "Avilash","Jha"};
        }
    }
}
