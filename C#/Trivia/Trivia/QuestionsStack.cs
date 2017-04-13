using System.Collections.Generic;
using System.Linq;

namespace Trivia
{
    internal class QuestionsStack
    {
        private readonly LinkedList<string> _stack;
        public string category { get; private set; }


        public QuestionsStack(string category)
        {
            this._stack = new LinkedList<string>();
            this.category = category;
            this.AddQuestion();
        }

        public void AddQuestion()
        {
            for (var i = 0; i < 50; i++)
            {
                _stack.AddLast(category+ " Question " + i);
            }
        }

        public string GetQuestion()
        {
            string question = _stack.First();
            RemoveQuestion();
            return question;
        }

        private void RemoveQuestion()
        {
            _stack.RemoveFirst();
        }
    }
}