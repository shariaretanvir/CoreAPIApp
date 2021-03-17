using System;
using System.Threading.Tasks;

namespace console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await TestAsyncAwaitMethods();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        public async static Task TestAsyncAwaitMethods()
        {
            Task<int> i = LongRunningMethod();
            await Task.Delay(1000);
            Console.WriteLine("start TestAsyncAwaitMethods...");
            await i;
            Console.WriteLine("end TestAsyncAwaitMethods...");
        }

        public static async Task<int> LongRunningMethod()
        {
            //await Method1();
            //await Method2();
            var method1 = Method1();
            var method2 = Method2();

            //method1.Wait();
            await method1;
            await method2;
            return 1;
        }

        public static async Task Method1() {
            await Task.Delay(3000);
            Console.WriteLine("Method 1 started");
        }
        public static async Task Method2()
        {
            await Task.Delay(2000);
            Console.WriteLine("Method 2 started");
        }
    }
}
