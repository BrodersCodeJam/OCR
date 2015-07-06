using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace brodersService.Controllers
{
    public class OCRController : ApiController
    {
        // GET: api/OCR
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OCR/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OCR
        public HttpResponseMessage Post()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return result;
        }

        // PUT: api/OCR/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OCR/5
        public void Delete(int id)
        {
        }
    }
}
