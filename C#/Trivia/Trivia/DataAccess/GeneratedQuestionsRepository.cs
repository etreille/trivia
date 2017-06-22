using System.Collections.Generic;
using Trivia.Domain;

namespace Trivia.DataAccess
{
    public class GeneratedQuestionsRepository : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category)
        {
            var questions = new LinkedList<string>();
            for (var i = 0; i < 50; i++)
            {
                questions.AddLast(category + " Question " + i);
            }

            return questions;
        }
    }
}