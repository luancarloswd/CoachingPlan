using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Commands.ReplyCommands;
using CoachingPlan.Domain.Contracts.Services;

namespace CoachingPlan.ApplicationService
{
    public class ReplyApplicationService : BaseApplicationService, IReplyApplicationService
    {
        private IReplyRepository _repository;

        public ReplyApplicationService(IReplyRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Reply Create(CreateReplyCommand command)
        {
            var service = new Reply(command.BodyReply, command.Group);
            service.Validate();
            _repository.Create(service);

            if (Commit())
                return service;

            return null;
        }

        public Reply Delete(Guid id)
        {
            var Service = _repository.GetOne(id);
            _repository.Delete(Service);

            if (Commit())
                return Service;

            return null;
        }

        public List<Reply> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Reply> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Reply GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }

        public List<Reply> GetAllByQuestion(Guid idQuestion)
        {
            return _repository.GetAllByQuestion(idQuestion);
        }

        public List<Reply> GetAllByQuestionAndStatusofTrue(Guid idQuestion)
        {
            return _repository.GetAllByQuestionAndStatusOfTrue(idQuestion);
        }

        public Reply Update(UpdateReplyCommand command)
        {
            var Reply = _repository.GetOne(command.Id);
            if (!string.IsNullOrEmpty(command.BodyReply))
                Reply.ChangeBodyReply(command.BodyReply);

            Reply.ChangeStatus(command.Status);

            _repository.Update(Reply);

            if (Commit())
                return Reply;

            return null;
        }

        public List<Reply> AddReplys(dynamic body)
        {
            List<Reply> listReply = new List<Reply>();
            foreach (var item in body)
            {
                if ((item.bodyReply != null) || (item.bodyReply != ""))
                {
                    if (item.id != null)
                        listReply.Add(
                            Update(new UpdateReplyCommand(
                            Guid.Parse((string)item.id),
                            (string)item.bodyReply)));
                    else
                        listReply.Add(new Reply( 
                            (string)item.bodyReply,
                            (string)item.group));
                }
            }
            return listReply;
        }

        public void CheckReplyRemovedOfQuestion(List<Reply> listReply, Guid idQuestion)
        {
            var oldList = _repository.GetAllByQuestion(idQuestion);
            foreach (var reply in oldList)
            {
                if (!listReply.Contains(reply))
                {
                    _repository.Delete(reply);
                }
            }
        }

        public void Dispose()
        {
            _repository = null;
        }
    }
}
