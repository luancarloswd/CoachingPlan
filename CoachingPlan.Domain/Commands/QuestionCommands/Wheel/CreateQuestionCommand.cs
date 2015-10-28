using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.QuestionCommands.Wheel
{
    public class CreateQuestionCommandWheel
    {
        public Guid Id { get; set; }
        public Guid IdEvaluationTool { get; private set; }
        public ETypeReply TypeReply { get; private set; }
        public ETypeQuestion TypeQuestion { get; private set; }
        public int? PhaseQuestion { get; private set; }
        public int StepQuestion { get; private set; }
        public string Enunciation { get; private set; }
        public string Education { get; private set; }

        public virtual EvaluationTool EvaluationTool { get; private set; }
        public virtual ICollection<Reply> Reply { get; private set; }
        public CreateQuestionCommandWheel(ETypeReply typeReply, ETypeQuestion typeQuestion, string enunciation, string education, ICollection<Reply> reply)
        {
            this.TypeReply = typeReply;
            this.TypeQuestion = typeQuestion;
            this.Enunciation = enunciation;
            this.Reply = reply;
        }
    }
}
