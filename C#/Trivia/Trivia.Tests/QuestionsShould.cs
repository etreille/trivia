using System;
using System.IO;
using NFluent;
using NUnit.Framework;

namespace Trivia.Tests
{
    public class QuestionsShould
    {
        [Test]
        public void AllowToUse5Categories()
        {
            // Arrange/Actors
            var stringWriter = new StringWriter();
            var previousConsoleOut = Console.Out;
            Console.SetOut(stringWriter);
            const string category5 = "Category5";
            IQuestionsRepository questionsRepository = new GeneratedQuestionsRepository();

            var questions = new Questions(new []{ "Category1", "Category2", "Category3", "Category4", category5 }, questionsRepository);

            // Act
            questions.AskQuestion(4);

            // Assert
            Assert.That(stringWriter.ToString().Contains(category5), Is.True);
            Check.That(stringWriter.ToString()).Contains(category5);
            Console.SetOut(previousConsoleOut);
        }
    }
}
