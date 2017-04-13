using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class StockQuestions
    {
        private readonly LinkedList<string> _stock;
        private string category { get; }


        public StockQuestions(string category)
        {
            this._stock = new LinkedList<string>();
            this.category = category;
        }

        public void AddQuestion(string question)
        {
            _stock.AddLast(question);
        }

        public string GetQuestion()
        {
            string question = _stock.First();
            RemoveQuestion();
            return question;
        }

        public void RemoveQuestion()
        {
            _stock.RemoveFirst();
        }
    }
}