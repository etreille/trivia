
using System;
using System.Collections.Generic;

namespace Trivia
{
    public class Questions
    {
        private List<QuestionsStack> _stackList = new List<QuestionsStack>();

        public Questions()
        {
            _stackList.Add(new QuestionsStack("Pop"));
            _stackList.Add(new QuestionsStack("Science"));
            _stackList.Add(new QuestionsStack("Sports"));
            _stackList.Add(new QuestionsStack("Rock"));
        }



        public string AskQuestion(int place)
        {
            QuestionsStack qStack = CurrentCategory(place);
            Console.WriteLine("The category is "+qStack.category);

            return qStack.GetQuestion();
        }


        private QuestionsStack CurrentCategory(int place)
        {
            return _stackList[place % 4];
        }

    }
}