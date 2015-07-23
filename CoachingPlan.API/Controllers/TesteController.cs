using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoachingPlan.Domain.Contracts.Services;
using Microsoft.Practices.Unity;

namespace CoachingPlan.API.Controllers
{
    public class TesteController : ApiController
    {
        // GET: api/Teste
        public void Get()
        {
            var container = new UnityContainer();
            var service = container.Resolve<ITelefoneService>();
            service.Register("222", "123123123");

        }

        // GET: api/Teste/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Teste
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Teste/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Teste/5
        public void Delete(int id)
        {
        }
    }
}
