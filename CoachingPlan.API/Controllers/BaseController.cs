using CoachingPlan.SharedKernel;
using CoachingPlan.SharedKernel.Events;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.API.Controllers
{
    public class BaseController : ApiController
    {
        public IEnumerable<IHandler<DomainNotification>> Notifications;
        public HttpResponseMessage ResponseMessage;

        public BaseController()
        {
            this.Notifications = DomainEvent.Container.GetService<IHandler<DomainNotification>>();
            this.ResponseMessage = new HttpResponseMessage();
        }

        public Task<HttpResponseMessage> CreateResponse(HttpStatusCode code, object result)
        {
            ResponseMessage = Request.CreateResponse(code, result);

            foreach (var notification in Notifications)
            {
                if (notification.HasNotifications())
                        ResponseMessage = Request.CreateResponse(HttpStatusCode.BadRequest, new { errors = notification.Notify() });
                }            

            return Task.FromResult<HttpResponseMessage>(ResponseMessage);
        }

        protected override void Dispose(bool disposing)
        {
            foreach (var notification in Notifications)
                notification.Dispose();
        }
    }
}