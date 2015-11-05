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
    public class BudgetController : BaseController
    {
        private readonly IBudgetApplicationService _serviceBudget;
        private readonly ICoachingProcessApplicationService _serviceCoachingProcess;
        private readonly IUserApplicationService _serviceUser;

        public BudgetController(IBudgetApplicationService serviceBudget,
            ICoachingProcessApplicationService serviceCoachingProcess,
            IUserApplicationService serviceUser)
        {
            this._serviceBudget = serviceBudget;
            this._serviceCoachingProcess = serviceCoachingProcess;
            this._serviceUser = serviceUser;
        }

        [Authorize(Roles = "Administrator, Coach")]
        [HttpGet]
        [Route("api/budgets")]
        public Task<HttpResponseMessage> Get()
        {
            var budgets = _serviceBudget.GetAll();
            return CreateResponse(HttpStatusCode.OK, budgets);
        }

        [Authorize(Roles = "Administrator, Coach, Coachee")]
        [HttpGet]
        [Route("api/budgets/{id}")]
        public Task<HttpResponseMessage> Get(string id)
        {
            var budget = _serviceBudget.GetOne(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, budget);
        }

        [Authorize(Roles = "Administrator, Coach")]
        [HttpPost]
        [Route("api/Budgets")]
        public Task<HttpResponseMessage> Post([FromBody]dynamic body)
        {
            var commandBudget = new CreateBudgetCommand(
                proposal: (string)body.proposal,
                price: (float)body.price,
                status: EBudgetStatus.Enviado,
                proposalDate: DateTime.Now,
                sessionPrice: (float)body.sessionPrice,
                idCoachingProcess: (Guid)body.idCoachingProcess
           );

            var budget = _serviceBudget.Create(commandBudget);
            var coachingProcess = _serviceCoachingProcess.GetOneIncludeDetails(budget.IdCoachingProcess);
            string msg = budget.Proposal + "\n Preço da sessão: " + budget.Price + "\n Total: " + budget.Price;
            foreach (var coachee in coachingProcess.Coachee)
                _serviceUser.SendEmail(coachee.IdUser, "Orçamento processo de coaching - CoachingPlan", msg);

            return CreateResponse(HttpStatusCode.Created, budget);
        }

        [Authorize(Roles = "Administrator, Coach")]
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

        [Authorize(Roles = "Administrator, Coach")]
        [HttpDelete]
        [Route("api/budgets/{id}")]
        public Task<HttpResponseMessage> Delete(string id)
        {
            var budget = _serviceBudget.Delete(Guid.Parse(id));
            return CreateResponse(HttpStatusCode.OK, budget);
        }
    }
}