using System;

namespace LearningExamples
{
    public class CoinsL : Currency<int>
    {
        public override event Action<int> OnValueChangedEvent;

        public CoinsL()
        {
            this.value = 0;
        }

        public override void Add(int amount)
        {
            throw new NotImplementedException();
        }

        public override void Spent(int amount)
        {
            throw new NotImplementedException();
        }
    }
}