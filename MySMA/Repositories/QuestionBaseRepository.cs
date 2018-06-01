using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using MySMA.Models;

namespace MySMA.Repositories
{
    public class QuestionBaseRepository : Repository<QuestionBase>, IQuestionBaseRepository
    {
        public QuestionBaseRepository() : this(new AppContext())
        {
            
        }

        public QuestionBaseRepository(IDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Retrieves a Question for a specific questionnaire, based on the QuestionDefinitionId.
        /// </summary>
        public QuestionBase Find(Guid questionnaireId, QuestionDefinitionId questionDefinitionId)
        {
            return All.FirstOrDefault(a => a.QuestionnaireId == questionnaireId && a.QuestionDefinitionId == questionDefinitionId);
        }
    }

}