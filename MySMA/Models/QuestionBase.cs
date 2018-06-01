using System;
using System.Web.Mvc;

namespace MySMA.Models
{
    [ModelBinder(typeof(QuestionBaseModelBinder))]
    public abstract class QuestionBase : EntityBase
    {
        public QuestionDefinitionId QuestionDefinitionId { get; set; }

        /// <summary>
        /// Parent Questionnaire to which this answer belongs
        /// </summary>
        /// 
        public Guid QuestionnaireId { get; set; }
    }
}