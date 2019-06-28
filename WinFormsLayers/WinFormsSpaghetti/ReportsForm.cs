using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsSpaghetti.CrmRepositoryService;

namespace WinFormsSpaghetti
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();

            CRMRepositoryClient crmRepositoryClient = new CRMRepositoryClient(new InstanceContext(Program.CallbackImplementation));

            var allCompanies = crmRepositoryClient.GetAllCompanies();
            var allEmployees = crmRepositoryClient.GetAllEmployees();

            Dictionary<long,List<long>> dictionary = new Dictionary<long, List<long>>();
            Dictionary<long ,List<long>> dictionary2 = new Dictionary<long, List<long>>();
            
            foreach (var company in allCompanies)
            {
                foreach (var employee in company.Employees)
                {
                    if (dictionary.ContainsKey(employee.Id))
                    {
                        dictionary[employee.Id].Add(company.Id);
                    }
                    else
                    {
                        dictionary.Add(employee.Id, new List<long>{company.Id});
                    }
                }
            }

            foreach (var keyVal in dictionary)
            {
                if (keyVal.Value.Count > 1)
                {
                    dictionary2.Add(keyVal.Key,keyVal.Value);
                }
            }


            if (dictionary2.Count > 0)
            {
                richTextBox1.AppendText("ZDRAJCY: \r\n");
                foreach (var kvp in dictionary2)
                {
                    richTextBox1.AppendText($"PRacownik : {allEmployees.Where(e => e.Id == kvp.Key).Select(e => e.Name + " " +e.Surname ).First()} pracuje jednoczesnie w  firmach: \r\n");
                    foreach (var companyId in kvp.Value)
                    {
                        richTextBox1.AppendText(allCompanies.Where(c => c.Id == companyId).Select(c => c.Name).First() + "\r\n");
                    }
                }
               
            }

        }
    }
}
