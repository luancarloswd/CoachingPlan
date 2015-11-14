using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.QuestionCommands.Wheel
{
    public class UpdateQuestionCommandWheel
    {
        public Guid Id { get; set; }
        public Guid IdEvaluationTool { get; private set; }
        public ETypeReply TypeReply { get; private set; }
        public ETypeQuestion TypeQuestion { get; private set; }
        public Nullable<int> PhaseQuestion { get; private set; }
        public Nullable<int> StepQuestion { get; private set; }
        public string Enunciation { get; private set; }
        public string Education { get; private set; }

        public virtual EvaluationTool EvaluationTool { get; private set; }
        public virtual ICollection<Reply> Reply { get; private set; }
        public UpdateQuestionCommandWheel(Guid id, ETypeReply typeReply, ETypeQuestion typeQuestion, string enunciation, string education, List<Reply> reply)
        {
            this.Id = id;
            this.TypeReply = typeReply;
            this.TypeQuestion = typeQuestion;
            this.Enunciation = enunciation;
            this.Reply = reply;
        }
    }
}
