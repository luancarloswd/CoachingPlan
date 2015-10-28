using System;
using System.Collections.Generic;
using CoachingPlan.Domain.Models;
using CoachingPlan.Infraestructure.Data;
using CoachingPlan.Domain.Contracts.Repositories;
using CoachingPlan.Domain.Contracts.Services;
using CoachingPlan.Domain.Commands.MessageCommands;

namespace CoachingPlan.ApplicationService
{
    public class MessageApplicationService : BaseApplicationService, IMessageApplicationService
    {
        private IMessageRepository _repository;

        public MessageApplicationService(IMessageRepository repository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._repository = repository;
        }
        public Message Create(CreateMessageCommand command)
        {
            var message = new Message(command.BodyMessage, command.Destination, command.Date, command.IdUser, false);
            message.Validate();
            _repository.Create(message);

            if (Commit())
                return message;

            return null;
        }

        public List<Message> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Message> GetAll(int take, int skip)
        {
            return _repository.GetAll(take, skip);
        }

        public Message Read(Guid id)
        {
            var message = GetOne(id);
            message.ChangeStatus(true);
            _repository.Update(message);

            if (Commit())
                return message;

            return null;
        }

        public List<Message> GetHistoryMessages(string idUser, string idDesdination)
        {
            return _repository.GetHistoryMessages(idUser, idDesdination);
        }

        public Message GetOne(Guid id)
        {
            return _repository.GetOne(id);
        }
        public void Dispose()
        {
            _repository = null;
        }
    }
}
