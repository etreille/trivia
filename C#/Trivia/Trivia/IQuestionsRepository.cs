using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public interface IQuestionsRepository
    {
        LinkedList<string> GetQuestions(string category);
    }

    class QuestionsRepositoryFromFile : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category)
        {
            throw new NotImplementedException();
        }
    }

    class QuestionsRepositoryFromDB : IQuestionsRepository
    {
        public LinkedList<string> GetQuestions(string category)
        {
            throw new NotImplementedException();
        }
    }

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
