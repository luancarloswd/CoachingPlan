using CoachingPlan.Domain.Commands.MessageCommands;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Services
{
    public interface IMessageApplicationService : IDisposable
    {
        Message GetOne(Guid id);
        List<Message> GetAll();
        List<Message> GetAll(int take, int skip);
        Message Create(CreateMessageCommand Message);
        Message Read(Guid id);
        List<Message> GetHistoryMessages(string idUser, string idDesdination);
    }
}
