using CoachingPlan.Domain.Enums;
using CoachingPlan.Domain.Models;
using System;
using System.Collections.Generic;

namespace CoachingPlan.Domain.Commands.QuestionCommands.Questionnaire
{
    public class CreateQuestionQuestionnaireCommand
    {
        public Guid Id { get; set; }
        public Guid IdEvaluationTool { get; set; }
        public ETypeReply TypeReply { get; set; }
        public ETypeQuestion TypeQuestion { get; set; }
        public int? PhaseQuestion { get; set; }
        public int StepQuestion { get; set; }
        public string Enunciation { get; set; }
        public string Education { get; set; }
        public string Group { get; set; }


        public virtual EvaluationTool EvaluationTool { get; private set; }
        public virtual ICollection<Reply> Reply { get; private set; }
        public CreateQuestionQuestionnaireCommand(ETypeReply typeReply, ETypeQuestion typeQuestion, string enunciation, string education, ICollection<Reply> reply, string group)
        {
            this.TypeReply = typeReply;
            this.TypeQuestion = typeQuestion;
            this.Enunciation = enunciation;
            this.Reply = reply;
            this.Group = group;
        }
    }
}
