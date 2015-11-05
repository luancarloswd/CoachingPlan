using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.EvaluationCoachCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class EvaluationCoachApplicationService : BaseApplicationService, IEvaluationCoachApplicationService
    {
        private IEvaluationCoachRepository _repository;

        public EvaluationCoachApplicationService(IEvaluationCoachRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public EvaluationCoach Create(CreateEvaluationCoachCommand command)
        {
            var evaluation = new EvaluationCoach(command.IdCoach, command.IdSession, command.Evaluation, command.Observation);
            _repository.Create(evaluation);

            if (Commit())
                return evaluation;

            return null;
        }

        public EvaluationCoach Delete(Guid id)
        {
            var evaluation = _repository.GetOne(id);
            _repository.Delete(evaluation);

            if (Commit())
                return evaluation;

            return null;
        }

        public List<EvaluationCoach> GetAll()
        {
            return _repository.GetAll();
        }

        public List<EvaluationCoach> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public EvaluationCoach GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<EvaluationCoach> GetAllBySession(Guid idSession)
        {
            return _repository.GetAllBySession(idSession);
        }
        public List<EvaluationCoach> GetAllByCoach(Guid idCoach)
        {
            return _repository.GetAllByCoach(idCoach);
        }

        public List<EvaluationCoach> GetAllByCoachAndSession(Guid idCoach, Guid idSession)
        {
            return _repository.GetAllByCoachAndSession(idCoach, idSession);
        }

        public EvaluationCoach Update(UpdateEvaluationCoachCommand command)
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
        public List<EvaluationCoach> AddToSession(dynamic body, Guid idSession)
        {
            List<EvaluationCoach> listEvaluationCoach = new List<EvaluationCoach>();
            foreach (var item in body)
            {
                if ((item.idSession != null) || (item.idSession != ""))
                {
                    var verify = _repository.GetAllByCoachAndSession(Guid.Parse((string)item.id), idSession);
                    if (verify.Count == 0)
                        listEvaluationCoach.Add(Create( new CreateEvaluationCoachCommand(Guid.Parse((string)item.id), idSession, new int())));
                    else
                    {
                        foreach (var evaluation in verify)
                            listEvaluationCoach.Add(evaluation);
                    }
                }
            }
            return listEvaluationCoach;
        }

        public void CheckEvaluationCoachRemoved(List<EvaluationCoach> listEvaluationCoach, Guid idSession)
        {
            var oldList = _repository.GetAllBySession(idSession);
            foreach (var evaluationCoach in oldList)
            {
                if (!listEvaluationCoach.Contains(evaluationCoach))
                {
                    Delete(evaluationCoach.Id);
                }
            }
        }
        public void Dispose()
        {
            _repository = null;
        }
    }
}
