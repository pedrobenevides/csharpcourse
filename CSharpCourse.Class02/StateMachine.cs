using System.Collections;
using System.Collections.Generic;

namespace CSharpCourse.Class02
{
    public class StateMachine : IEnumerator<int>
    {
        private int state;

        public StateMachine()
        {
            state = 0;
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public bool MoveNext()
        {
            switch (state)
            {
                case 0: Current = 1; state++; return true;
                case 1: Current = 2; state++; return true;
                case 2: Current = 3; state++; return true;
                case 3: Current = 4; state++; return true;
                case 4: Current = 5; state++; return true;
                case 5: Current = 6; state++; return true;
                case 6: Current = 7; state++; return true;
                case 7: Current = 8; state++; return true;
                case 8: Current = 9; state++; return true;
                case 9: Current = 10; state++; return true;
                default: return false;
            }
        }

        public void Reset()
        {
            throw new System.NotSupportedException("You should create a new instance");
        }

        public int Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
