using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoNET
{
    class Program
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine();
            Console.WriteLine(" Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            await Task.Delay(5000);
            Console.WriteLine(" Executando função assíncrona");
        }
    }
}
