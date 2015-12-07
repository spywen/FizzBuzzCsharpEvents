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
                OnEnd(new EventArgs());
            }
            else if (Total % 3 == 0)
            {
                OnDivisibleBy3(new EventArgs());
            }
            else if (Total%5 == 0)
            {
                OnDivisibleBy5(new EventArgs());
            }
            else
            {
                OnNotDivisibleBy3Or5(new IntegerEventArgs{Value = Total});
            }
        }


        public event EventHandler<EventArgs> End;
        protected virtual void OnEnd(EventArgs e)
        {
            EventHandler<EventArgs> handler = End;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        public event EventHandler<EventArgs> Fizz;
        protected virtual void OnDivisibleBy3(EventArgs e)
        {
            EventHandler<EventArgs> handler = Fizz;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<EventArgs> Buzz;
        protected virtual void OnDivisibleBy5(EventArgs e)
        {
            EventHandler<EventArgs> handler = Buzz;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<IntegerEventArgs> Other;
        protected virtual void OnNotDivisibleBy3Or5(IntegerEventArgs e)
        {
            EventHandler<IntegerEventArgs> handler = Other;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class IntegerEventArgs : EventArgs
    {
        public int Value { get; set; }
    }
}
