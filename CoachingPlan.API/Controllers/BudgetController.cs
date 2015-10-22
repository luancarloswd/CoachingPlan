using CoachingPlan.API.Controllers;
using CoachingPlan.Domain.Commands.BudgetCommands;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Enums;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CoachingPlan.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class BudgetController : BaseController
    {
        private readonly IBudgetApplicationService _serviceBudget;
        private readonly ICoachingProcessApplicationService _serviceCoachingProcess;

        public BudgetController(IBudgetApplicationService serviceBudget,
            ICoachingProcessApplicationService serviceCoachingProcess)
        {
            this._serviceBudget = serviceBudget;
            this._serviceCoachingProcess = serviceCoachingProcess;
        }

        [HttpGet]
        [Route("api/budgets")]
        public Task<HttpResponseMessage> Get()
        {
            var budgets = _serviceBudget.GetAll();
            return CreateResponse(HttpStatusCode.OK, budgets);
        }

        [HttpGet]
        [Route("api/budgets/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var budget = _serviceBudget.GetOne(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, budget);
        }

        [HttpPost]
        [Route("api/Budgets")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var commandBudget = new CreateBudgetCommand(
                proposal: (string)body.proposal,
                price: (float)body.price,
                status: (EBudgetStatus)body.status,
                proposalDate: DateTime.Now,
                sessionPrice: (float)body.sessionPrice,
                idCoachingProcess: (Guid)body.idCoachingProcess
           );

            var budget = _serviceBudget.Create(commandBudget);

            return CreateResponse(HttpStatusCode.Created, budget);
        }


        [HttpPut]
        [Route("api/budgets")]
        public Task<HttpResponseMessage> Put([FromBody]dynamic body)
        {
            var commandBudget = new UpdateBudgetCommand(
                id: Guid.Parse((string)body.id),
                proposal: (string)body.proposal,
                price: (float)body.price,
                status: (EBudgetStatus)body.status,
                proposalDate: (DateTime)body.proposalDate,
                sessionPrice: (float)body.sessionPrice,
                idCoachingProcess: (Guid)body.idCoachingProcess
              );

            var budget = _serviceBudget.Update(commandBudget);
            return CreateResponse(HttpStatusCode.Created, budget);
        }

        [HttpDelete]
        [Route("api/budgets/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var budget = _serviceBudget.Delete(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, budget);
        }
    }
}