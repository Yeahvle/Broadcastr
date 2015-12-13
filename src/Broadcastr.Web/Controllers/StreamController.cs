using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Broadcastr.Web.Controllers
{
    [Route("api/[controller]")]
    public class StreamController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("{id:guid}")]
        public async Task Get(Guid id)
        {
            HttpContext.Response.ContentType = "video/mp4";

            using (var reader = System.IO.File.OpenRead("sample-vid.mp4"))
            {
                byte[] buffer = new byte[8192];
                var bytesRead = 0;
                do
                {
                    bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length);

                    await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                    await HttpContext.Response.Body.FlushAsync();
                }
                while (bytesRead > 0);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
