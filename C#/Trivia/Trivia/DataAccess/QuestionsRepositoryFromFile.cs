using System;
using System.Collections.Generic;
using Trivia.Domain;

namespace Trivia.DataAccess
{
    class QuestionsRepositoryFromFile : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category)
        {
            throw new NotImplementedException();
        }
    }
}