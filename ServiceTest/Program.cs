using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTest.ServiceReference;

namespace ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(1000);
            var client = new UsersRegistrationServiceClient();
            var result = client.LogIn("Login", "Password");
            Console.WriteLine("after");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
