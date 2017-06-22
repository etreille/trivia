namespace Trivia.Domain
{
    public class CurrentPlayerRolledTheDice
    {
        public string CurrentName { get; private set; }
        public int DiceValue { get; private set; }

        public CurrentPlayerRolledTheDice(string currentName, int diceValue)
        {
            CurrentName = currentName;
            DiceValue = diceValue;
        }
    }
}