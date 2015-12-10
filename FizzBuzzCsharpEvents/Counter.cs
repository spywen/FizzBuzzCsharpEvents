using System;

namespace FizzBuzzCsharpEvents
{
    class Counter
    {
        private int Limit { get; set; }
        private int Total { get; set; }

        public Counter(int limit)
        {
            Limit = limit;
        }

        public void Increment()
        {
            Total++;
            if (Total >= Limit)
            {
                if(End != null) End(this, EventArgs.Empty);
            }
            else if (Total % 3 == 0)
            {
                if (Fizz != null) Fizz(this, EventArgs.Empty);
            }
            else if (Total%5 == 0)
            {
                if (Buzz != null) Buzz(this, EventArgs.Empty);
            }
            else
            {
                if (Other != null) Other(this, new IntegerEventArgs{Value = Total});
            }
        }

        public event EventHandler<EventArgs> End;
        public event EventHandler<EventArgs> Fizz;
        public event EventHandler<EventArgs> Buzz;
        public event EventHandler<IntegerEventArgs> Other;
    }

    public class IntegerEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
