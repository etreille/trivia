using System.Collections.Generic;

namespace Trivia.Domain
{
    public class Questions
    {
        private readonly List<QuestionsStack> _categories = new List<QuestionsStack>();

        public Questions(IEnumerable<string> categories, IQuestionsRepository questionsRepository, IQuestionUI questionUi)
        {
            GenerateQuestions(categories, questionsRepository, questionUi);
        }

        private void GenerateQuestions(IEnumerable<string> categories, IQuestionsRepository questionsRepository, IQuestionUI questionUi)
        {
            foreach (var category in categories)
            {
                var questionsStack = new QuestionsStack(category, questionsRepository, questionUi);
                _categories.Add(questionsStack);
                
            }
        }

        public void AskQuestion(int playerPlace)
        {
            CurrentCategory(playerPlace).AskQuestionAndDiscardIt();
        }
        private QuestionsStack CurrentCategory(int playerPlace)
        {
            return _categories[playerPlace % _categories.Count];
        }
    }
}