using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    public class QuestionsStack
    {
        private readonly string _category;
        private readonly LinkedList<string> questions = new LinkedList<string>();

        private IQuestionsRepository questionsRepository;

        public QuestionsStack(string category, IQuestionsRepository questionsRepository)
        {
            _category = category;

            this.questionsRepository = questionsRepository;

            questions = this.questionsRepository.GetQuestions(category);
            
        }

        public void AskQuestionAndDiscardIt()
        {
            Console.WriteLine("The category is " + _category);
            Console.WriteLine(questions.First());
            questions.RemoveFirst();
        }
    }
}