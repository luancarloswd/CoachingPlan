﻿using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Contracts.Repositories
{
    public interface IMessageRepository : IDisposable
    {
        Message GetOne(Guid id);
        List<Message> GetAll();
        List<Message> GetAll(int take, int skip);
        void Create(Message Message);
        void Update(Message Message);
        List<Message> GetHistoryMessages(string idUser, string idDesdination);
    }
}
