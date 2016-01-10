using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCourse.Class02
{
    class Program
    {
        private static bool mustStop = false;

        static void Main(string[] args)
        {
            var list = List1To10();
            var greatherThanFive = List1To10().Onde(i => i > 5).ToList(); //Perform fetch.
            
            MultipleEnumeration();

            Console.ReadKey();
        }

        public static IEnumerable<int> List1To10()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
            yield return 10;
        }

        public static IEnumerable<int> List1To10WithBreak()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            if(mustStop)
                yield break;
            yield return 4;
            yield return 5;
            yield return 6;
            yield return 7;
            yield return 8;
            yield return 9;
            yield return 10;
        }

        private static void PerformStateMachine()
        {
            var stateMachine = new StateMachine();
            while (stateMachine.MoveNext())
            {
                Console.WriteLine(stateMachine.Current);
            }

        }

        private static void MultipleEnumeration()
        {
            var listBreak1 = List1To10WithBreak();

            foreach (var item in listBreak1)
            {
                Console.WriteLine(item);
            }

            mustStop = true;
            
            foreach (var item in listBreak1)
            {
                Console.WriteLine(item);
            }
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<T> Onde<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
                if (predicate(item))
                    yield return item;
        } 
    }
}
