using System.Collections.Generic;
using System.Web.Http;
using DI08.Services;

namespace DI08.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IEmailsService _emailsService;
        public ValuesController(IEmailsService emailsService)
        {
            _emailsService = emailsService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            _emailsService.SendEmail();
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}