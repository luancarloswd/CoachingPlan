using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.QuestionCommands
{
    public class UpdateQuestionCommand
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
        public UpdateQuestionCommand(Guid id, ETypeReply typeReply, ETypeQuestion typeQuestion, int stepQuestion, string enunciation, string education, ICollection<Reply> reply, int? phaseQuestion)
        {
            this.Id = id;
            this.TypeReply = typeReply;
            this.TypeQuestion = typeQuestion;
            this.StepQuestion = stepQuestion;
            this.Enunciation = enunciation;
            this.PhaseQuestion = phaseQuestion;
            this.Reply = reply;
        }
    }
}
