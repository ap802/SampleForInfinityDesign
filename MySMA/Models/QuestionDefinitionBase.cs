namespace MySMA.Models
{
    public abstract class QuestionDefinitionBase
    {
        public QuestionDefinitionId Id { get; set; }
        public string PromptText { get; set; }

        private QuestionDefinitionId? _defaultNextQuestionId;
        public QuestionDefinitionId? DefaultNextQuestionId { set { _defaultNextQuestionId = value; } }

        public virtual QuestionDefinitionId? GetNextQuestionId(QuestionBase question)
        {
            // Just return default for all usual cases.
            return _defaultNextQuestionId;
        }

        /// <summary>
        /// Implements a Question of the appropriate type based on the concrete type of QuestionDefinitionBase.
        /// </summary>
        /// <param name="questionnaireId"></param>
        /// <returns></returns>
        public QuestionBase CreateQuestion()
        {
            var question = CreateQuestionOfCorrectType();

            question.QuestionDefinitionId = Id;

            return question;
        }

        /// <summary>
        /// Note to inheritors: Return an instance of the appropriate concrete type of QuestionBase corresponding
        /// to the concrete type of QuestionDefinitionBase.
        /// </summary>
        /// <returns></returns>
        protected abstract QuestionBase CreateQuestionOfCorrectType();
    }
}