using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            WSDualHttpBinding binding = new WSDualHttpBinding();
          //  EndpointAddress baseAddress2 = new EndpointAddress("http://localhost:64080/crm");
            binding.ClientBaseAddress = new Uri("http://localhost:64080/client");
            binding.Security.Mode = WSDualHttpSecurityMode.None;


            Uri baseAddress = new Uri("http://localhost:64080/crm");

            using (ServiceHost host = new ServiceHost(typeof(CrmRepositoryService),baseAddress))
            {

                host.AddServiceEndpoint(typeof(ICRMRepository), binding, baseAddress);
                               
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                
                host.Description.Behaviors.Add(smb);
                ServiceAuthenticationBehavior bechAuthenticationBehavior = new ServiceAuthenticationBehavior();
                bechAuthenticationBehavior.AuthenticationSchemes = AuthenticationSchemes.None;
                

                host.Open();

                Console.WriteLine($"The service is ready at {baseAddress}" );
                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();

                // Close the ServiceHost.
                host.Close();
            }
        }
    }
}
