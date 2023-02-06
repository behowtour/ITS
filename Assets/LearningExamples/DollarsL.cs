using System;
using System.Numerics;

namespace LearningExamples
{
    public class DollarsL : Currency<BigInteger>
    {
        public override event Action<BigInteger> OnValueChangedEvent;

        public DollarsL()
        {
            this.value = new BigInteger(0);
        }

        public override void Add(BigInteger amount)
        {
            throw new NotImplementedException();
        }

        public override void Spent(BigInteger amount)
        {
            throw new NotImplementedException();
        }
    }
}