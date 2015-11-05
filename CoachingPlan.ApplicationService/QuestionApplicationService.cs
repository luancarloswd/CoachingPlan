using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.QuestionCommands;
using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Commands.QuestionCommands.Questionnaire;
using CoachingPlan.Domain.Commands.QuestionCommands.Wheel;
using CoachingPlan.Domain.Commands.QuestionCommands.Script;
using CoachingPlan.Domain.Commands.ReplyCommands;

namespace CoachingPlan.ApplicationService
{
    public class QuestionApplicationService : BaseApplicationService, IQuestionApplicationService
    {
        private IQuestionRepository _repository;
        private IReplyApplicationService _serviceReply;

        public QuestionApplicationService(IQuestionRepository repository, IReplyApplicationService serviceReply, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
            this._serviceReply = serviceReply;
        }
        public Question Create(CreateQuestionCommand command)
        {
            var service = new Question(command.TypeReply, command.TypeQuestion, command.StepQuestion, command.Enunciation, command.Education, command.Reply, command.PhaseQuestion, command.Group);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        private Question Create(CreateQuestionQuestionnaireCommand command)
        {
            var service = new Question(command.TypeReply, command.TypeQuestion, command.StepQuestion, command.Enunciation, command.Education, command.Reply, command.PhaseQuestion, command.Group);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        private Question Create(CreateQuestionCommandWheel command)
        {
            var service = new Question(ETypeReply.Quantitative, ETypeQuestion.Sigle, command.StepQuestion, command.Enunciation, command.Education, command.Reply, command.PhaseQuestion, null);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }
        private Question Create(CreateQuestionCommandScript command)
        {
            var service = new Question(ETypeReply.Qualitative, ETypeQuestion.Sigle, command.StepQuestion, command.Enunciation, command.Education, command.Reply, command.PhaseQuestion, null);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public Question Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<Question> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Question> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Question GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<Question> GetAllByEvaluationTool(Guid evaluationTool)
        {
            return _repository.GetAllByEvaluationTool(evaluationTool);
        }

        public Question Update(UpdateQuestionCommand command)
        {
            var Question = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Enunciation))
                Question.ChangeEnunciation(command.Enunciation);
            if (!string.IsNullOrEmpty(command.Education))
                Question.ChangeEducation(command.Education);
            if (command.PhaseQuestion != null)
                Question.ChangePhaseQuestion(command.PhaseQuestion);
            if (command.StepQuestion != null)
                Question.ChangeStepQuestion(command.StepQuestion);
            if (command.TypeQuestion != 0)
                Question.ChangeTypeQuestion(command.TypeQuestion);
            if (command.TypeReply != 0)
                Question.ChangeTypeReply(command.TypeReply);

            if (command.Reply.Count > 0)
                foreach (var reply in command.Reply)
                Question.AddReply(reply);

            _repository.Update(Question);

            if (Commit())
                return Question;

            return null;
        }

        private Question Update(UpdateQuestionCommandQuestionnaire command)
        {
            var Question = _repository.GetOne(command.Id);
            if (!String.IsNullOrEmpty(command.Enunciation))
                Question.ChangeEnunciation(command.Enunciation);
            if (!String.IsNullOrEmpty(command.Education))
                Question.ChangeEducation(command.Education);
            if (!String.IsNullOrEmpty(command.Group))
                Question.ChangeGroup(command.Group);
            if (command.TypeQuestion != 0)
                Question.ChangeTypeQuestion(command.TypeQuestion);
            if (command.TypeReply != 0)
                Question.ChangeTypeReply(command.TypeReply);

            if (command.Reply.Count > 0)
                foreach (var reply in command.Reply)
                    Question.AddReply(reply);

            _repository.Update(Question);

            if (Commit())
                return Question;

            return null;
        }

        private Question Update(UpdateQuestionCommandWheel command)
        {
            var Question = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Enunciation))
                Question.ChangeEnunciation(command.Enunciation);
            if (!string.IsNullOrEmpty(command.Education))
                Question.ChangeEducation(command.Education);

            if (command.Reply.Count > 0)
                foreach (var reply in command.Reply)
                    Question.AddReply(reply);

            _repository.Update(Question);

            if (Commit())
                return Question;

            return null;
        }

        private Question Update(UpdateQuestionCommandScript command)
        {
            var Question = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.Enunciation))
                Question.ChangeEnunciation(command.Enunciation);
            if (!string.IsNullOrEmpty(command.Education))
                Question.ChangeEducation(command.Education);

            if (command.Reply.Count > 0)
                foreach (var reply in command.Reply)
                    Question.AddReply(reply);

            _repository.Update(Question);

            if (Commit())
                return Question;

            return null;
        }

        public List<Question> AddToEvaluationTool(dynamic body, ETypeEvaluationTool type)
        {
            if (type == ETypeEvaluationTool.Questionnaire)
                return AddToEvaluationToolQuestionnaire(body);
            else if (type == ETypeEvaluationTool.Script)
                return AddToEvaluationToolScript(body);
            else if (type == ETypeEvaluationTool.Wheel)
                return AddToEvaluationToolWheel(body);
            else
                return null;
        }

        private List<Question> AddToEvaluationToolQuestionnaire(dynamic body)
        {
            List<Question> listQuestion = new List<Question>();
            foreach (var item in body)
            {
                var listReply = _serviceReply.AddReplys(item.reply);
                if ((item.typeQuestion != 0))
                {
                    if (item.id != null)
                        listQuestion.Add(
                            Update(new UpdateQuestionCommandQuestionnaire(
                            Guid.Parse((string)item.id),
                            (ETypeReply)item.typeReply,
                            (ETypeQuestion)item.typeQuestion,
                            (string)item.enunciation,
                            (string)item.education,
                            listReply,
                            (string)item.group)));
                    else
                        listQuestion.Add(new Question(
                            (ETypeReply)item.typeReply,
                            (ETypeQuestion)item.typeQuestion,
                            (int)0,
                            (string)item.enunciation,
                            (string)item.education,
                            listReply,
                            (int)0,
                            (string)item.group));
                }
                if (item.id != null)
                    _serviceReply.CheckReplyRemovedOfQuestion(listReply, Guid.Parse((string)item.id));
            }
            return listQuestion;
        }

        private List<Question> AddToEvaluationToolWheel(dynamic body)
        {
            List<Question> listQuestion = new List<Question>();
            foreach (var item in body)
            {
                if ((item.enunciation != null && item.enunciation != ""))
                {
                    if (item.id != null)
                        listQuestion.Add(
                            Update(new UpdateQuestionCommandWheel(
                            Guid.Parse((string)item.id),
                            (ETypeReply)item.typeReply,
                            (ETypeQuestion)item.typeQuestion,
                            (string)item.enunciation,
                            (string)item.education
                            )));
                    else
                    {
                        List<Reply> listReply = new List<Reply>();
                        for (var i = 1; i <= 10; i++)
                            listReply.Add(new Reply(i.ToString(), null));
                        listQuestion.Add(new Question(
                            (ETypeReply)item.typeReply,
                            (ETypeQuestion)item.typeQuestion,
                            0,
                            (string)item.enunciation,
                            (string)item.education,
                            listReply,
                            0,
                            null));
                    }
                }
            }
            return listQuestion;
        }

        private List<Question> AddToEvaluationToolScript(dynamic body)
        {
            List<Question> listQuestion = new List<Question>();
            foreach (var item in body)
            {
                var listReply = _serviceReply.AddReplys(item.reply);
                if ((item.enunciation != null && item.enunciation != ""))
                {
                    if (item.id != null)
                        listQuestion.Add(
                            Update(new UpdateQuestionCommandScript(
                            Guid.Parse((string)item.id),
                            (ETypeReply)item.typeReply,
                            (ETypeQuestion)item.typeQuestion,
                            (int)item.step,
                            (string)item.enunciation,
                            (string)item.education,
                            listReply)));
                    else
                        listQuestion.Add(new Question(
                            (ETypeReply)item.typeReply,
                            (ETypeQuestion)item.typeQuestion,
                            (int)item.stepQuestion,
                            (string)item.enunciation,
                            (string)item.education,
                            listReply,
                            0,
                            null));
                }
            }
            return listQuestion;
        }

        public void CheckQuestionRemoved(List<Question> listQuestion, Guid idEvaluationTool)
        {
            var oldList = _repository.GetAllByEvaluationTool(idEvaluationTool);
            foreach (var question in oldList)
            {
                if (!listQuestion.Contains(question))
                {
                    _repository.Delete(question);
                }
            }
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
