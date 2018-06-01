using MySMA.Models;
using System;
using System.Collections.Generic;

namespace MySMA.Tests.Mocks
{
    public class FakeAppContext : FakeDbContextBase
    {
        public FakeDbSet<QuestionBase> QuestionBases { get; private set; }

        protected override void AddFakeDbSetsToDictionary()
        {
            QuestionBases = new FakeDbSet<QuestionBase>();

            _dbSets = new Dictionary<Type, object>() { { typeof(QuestionBase), QuestionBases } };
        }
    }
}
