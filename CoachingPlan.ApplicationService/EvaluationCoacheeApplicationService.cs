using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.EvaluationCoacheeCommands;

namespace CoachingPlan.ApplicationService
{
    public class EvaluationCoacheeApplicationService : BaseApplicationService, IEvaluationCoacheeApplicationService
    {
        private IEvaluationCoacheeRepository _repository;

        public EvaluationCoacheeApplicationService(IEvaluationCoacheeRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public EvaluationCoachee Create(CreateEvaluationCoacheeCommand command)
        {
            var evaluation = new EvaluationCoachee(command.IdCoachee, command.IdSession, command.Evaluation, command.Observation);
            _repository.Create(evaluation);

            if (Commit())
                return evaluation;

            return null;
        }

        public EvaluationCoachee Delete(Guid id)
        {
            var evaluation = _repository.GetOne(id);
            _repository.Delete(evaluation);

            if (Commit())
                return evaluation;

            return null;
        }

        public List<EvaluationCoachee> GetAll()
        {
            return _repository.GetAll();
        }

        public List<EvaluationCoachee> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public EvaluationCoachee GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<EvaluationCoachee> GetAllBySession(Guid idSession)
        {
            return _repository.GetAllBySession(idSession);
        }
        public List<EvaluationCoachee> GetAllByCoachee(Guid idCoachee)
        {
            return _repository.GetAllByCoachee(idCoachee);
        }

        public List<EvaluationCoachee> GetAllByCoacheeAndSession(Guid idCoachee, Guid idSession)
        {
            return _repository.GetAllByCoacheeAndSession(idCoachee, idSession);
        }

        public EvaluationCoachee Update(UpdateEvaluationCoacheeCommand command)
        {
            var evaluation = _repository.GetOne(command.Id);
            if (command.Evaluation > 0)
                evaluation.ChangeEvaluation(command.Evaluation);
            if (!string.IsNullOrEmpty(command.Observation))
                evaluation.ChangeObservation(command.Observation);

            _repository.Update(evaluation);

            if (Commit())
                return evaluation;

            return null;
        }

        public List<EvaluationCoachee> AddToSession(dynamic body, Guid idSession)
        {
            List<EvaluationCoachee> listEvaluationCoachee = new List<EvaluationCoachee>();
            foreach (var item in body)
            {
                if ((item.idSession != null) || (item.idSession != ""))
                {
                    var verify = _repository.GetAllByCoacheeAndSession(Guid.Parse((string)item.id), idSession);
                    if (verify.Count == 0)
                        listEvaluationCoachee.Add(Create(new CreateEvaluationCoacheeCommand(Guid.Parse((string)item.id), idSession, new int())));
                    else
                    {
                        foreach (var evaluation in verify)
                            listEvaluationCoachee.Add(evaluation);
                    }
                }
            }
            return listEvaluationCoachee;
        }

        public void CheckEvaluationCoacheeRemoved(List<EvaluationCoachee> listEvaluationCoachee, Guid idSession)
        {
            var oldList = _repository.GetAllBySession(idSession);
            foreach (var evaluationCoachee in oldList)
            {
                if (!listEvaluationCoachee.Contains(evaluationCoachee))
                {
                    Delete(evaluationCoachee.Id);
                }
            }
        }
        public void Dispose()
        {
            _repository = null;
        }
    }
}
