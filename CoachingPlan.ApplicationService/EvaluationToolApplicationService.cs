using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.EvaluationToolCommands;

namespace CoachingPlan.ApplicationService
{
    public class EvaluationToolApplicationService : BaseApplicationService, IEvaluationToolApplicationService
    {
        private IEvaluationToolRepository _repository;

        public EvaluationToolApplicationService(IEvaluationToolRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public EvaluationTool Create(CreateEvaluationToolCommand command)
        {
            var service = new EvaluationTool(command.Name, command.Type, command.Question, command.Author, command.Coach);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public EvaluationTool Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<EvaluationTool> GetAll()
        {
            return _repository.GetAll();
        }

        public List<EvaluationTool> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public EvaluationTool GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }
        public EvaluationTool GetOneIncludeFilledTool(Guid id)
        {
            return _repository.GetOneIncludeFilledTool(id);
        }
        public List<EvaluationTool> GetAllByCoach(Guid idCoach)
        {
            return _repository.GetAllByCoach(idCoach);
        }

        public List<EvaluationTool> GetAllIncludeDetails()
        {
            return _repository.GetAllIncludeDetails();
        }
        public List<EvaluationTool> GetAllByCoachee(Guid idCoachee)
        {
            return _repository.GetAllByCoachee(idCoachee);
        }

        public EvaluationTool Update(UpdateEvaluationToolCommand command)
        {
            var evaluationTool = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Author))
                evaluationTool.ChangeAuthor(command.Author);
            if (!string.IsNullOrEmpty(command.Name))
                evaluationTool.ChangeName(command.Name);
            if (command.Type != 0)
                evaluationTool.ChangeType(command.Type);

            if (command.Question.Count > 0)
                foreach (var question in command.Question)
                evaluationTool.AddQuestion(question);

            _repository.Update(evaluationTool);

            if (Commit())
                return evaluationTool;

            return null;
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
