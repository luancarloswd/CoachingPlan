using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.ReplyCommands
{
    public class UpdateReplyCommand
    {
        public Guid Id { get; set; }
        public Guid IdQuestion { get; set; }
        public string BodyReply { get; set; }
        public bool Status { get; set; }

        public virtual Question Question { get; set; }

        public UpdateReplyCommand(Guid id, string bodyReply, bool status)
        {
            this.Id = id;
            this.BodyReply = bodyReply;
            this.Status = status;
        }
    }
}

