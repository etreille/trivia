using System;
using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class StockQuestions
    {
        private readonly LinkedList<string> stock = new LinkedList<string>();

        public void addQuestion(string question)
        {
            stock.AddLast(question);
        }

        public string getQuestion()
        {
            string question =stock.First();
            this.removeQuestion();
            return question;
        }

        public void removeQuestion()
        {
            stock.RemoveFirst();
        }
    }
}