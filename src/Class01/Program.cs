using System;
using System.Reflection.Emit;

namespace Class01
{
    class Program
    {
        static void Main(string[] args)
        {
            var intType = typeof(int);
            var dynamicMethod = new DynamicMethod("Soma", intType, new[] { intType, intType });
            Func<int, int, int> sumFunc = (x, y) => x + y;

            var ilGenerator = dynamicMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Nop);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Add);
            //ilGenerator.Emit(OpCodes.Stloc_0);
            ilGenerator.Emit(OpCodes.Ret);

            var sumCreatedAtExecution = dynamicMethod.CreateDelegate(typeof(Func<int, int, int>)) as Func<int, int, int>;
            Console.WriteLine($"Soma criado em tempo de execução, o resultado é {sumCreatedAtExecution(2, 2)}");
            Console.WriteLine($"Soma criado em tempo de desenvolvimento, o resultado é {sumFunc.Invoke(2, 2)}");
            Console.ReadKey();
        }

        private static int Soma(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
