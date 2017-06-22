using System.Collections.Generic;

namespace Trivia
{
    public interface IQuestionsRepository
    {
        LinkedList<string> GetQuestions(string category);
    }
}
