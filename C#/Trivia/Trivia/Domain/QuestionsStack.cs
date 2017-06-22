using System.Collections.Generic;
using System.Linq;

namespace Trivia.Domain
{
    public class QuestionsStack
    {
        private readonly string _category;
        private readonly IQuestionUI _questionUi;
        private readonly LinkedList<string> questions = new LinkedList<string>();
        

        public QuestionsStack(string category, IQuestionsRepository questionsRepository, IQuestionUI questionUi)
        {
            _category = category;
            _questionUi = questionUi;

            questions = questionsRepository.GetQuestions(category);
            
        }

        public void AskQuestionAndDiscardIt()
        {
            _questionUi.Display("The category is " + _category);
            _questionUi.Display(questions.First());
            questions.RemoveFirst();
        }
    }
}