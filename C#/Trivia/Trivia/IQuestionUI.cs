using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia
{
    public interface IQuestionUI
    {
        void Display(string message);

    }

    public class ConsoleUI : IQuestionUI
    {
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}
