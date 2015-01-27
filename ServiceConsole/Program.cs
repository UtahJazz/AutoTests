using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ServiceConsole
{
    class Program
    {
        private static void Main(string[] args)
        {
            var uri = new Uri("http://localhost:8733");
            using (var host = new ServiceHost(typeof(AutoTests.AutoTestingService), uri))
            {
                Console.WriteLine("Prepping CheckoutService server");
                /*ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                host.Description.Behaviors.Add(smb);*/

                host.Open();

                /*Console.Clear();
                Console.WriteLine("CheckoutService server up and running");
                Console.WriteLine("Press Return to stop service at any point");*/
                Console.ReadLine();
                host.Close();
            }

        }
    }
}
