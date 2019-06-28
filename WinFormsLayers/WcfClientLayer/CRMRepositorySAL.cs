using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using WcfClientLayer.CrmRepositoryClient;


namespace WcfClientLayer
{
    public class CRMRepositorySAL
    {
        private readonly CRMRepositoryClient client;


        public event EventHandler SignalFromServer; 

        public CRMRepositorySAL()
        {
            CallbackHandler.Instance.SignalArrived += new EventHandler<SignalArgs>(OnSignalArrived);
            client = new CRMRepositoryClient(new InstanceContext(CallbackHandler.Instance),"WSDualHttpBinding_ICRMRepository");
        }



        private void OnSignalArrived(object sender, SignalArgs e)
        {

            if (e.ServerAlive && SignalFromServer != null)
            {
                SignalFromServer(this,new EventArgs());
            }
        }

        public List<Company> GetAllCompanies()
        {
            return client.GetAllCompanies();
        }


        public void SendKeepalive()
        {
            client.KeepAlive();
        }

        public List<Employee> GetEmployeesByCompany(string companyName)
        {
            return client.GetEmployeesByCompany(companyName);
        }
    }
}
