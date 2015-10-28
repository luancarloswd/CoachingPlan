using CoachingPlan.Domain.Models;
using System;

namespace CoachingPlan.Domain.Commands.ReplyCommands
{
    public class CreateReplyCommand
    {
        public Guid Id { get; private set; }
        public Guid IdQuestion { get; private set; }
        public string BodyReply { get; private set; }
        public bool Status { get; private set; }
        public string Group { get; private set; }

        public virtual Question Question { get; private set; }

        public CreateReplyCommand(string bodyReply, string group)
        {
            this.BodyReply = bodyReply;
            this.Group = group;
        }
    }
}
