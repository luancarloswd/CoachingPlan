using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.ReplyCommands
{
    public class UpdateReplyCommand
    {
        public Guid Id { get; private set; }
        public Guid IdQuestion { get; private set; }
        public string BodyReply { get; private set; }
        public bool Status { get; private set; }

        public virtual Question Question { get; private set; }

        public UpdateReplyCommand(Guid id, string bodyReply)
        {
            this.Id = id;
            this.BodyReply = bodyReply;
        }
    }
}

