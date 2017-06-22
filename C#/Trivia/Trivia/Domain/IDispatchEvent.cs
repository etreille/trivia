namespace Trivia.Domain
{
    internal interface IDispatchEvent
    {
        void Dispatch<TEvent>(TEvent tEvent);
    }
}