using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppCW02.Shared.Models
{
    public class CompanyModel
    {
        public Guid guid { get; set; }
        public string companyName { get; set; }
        public string companyType { get; set; }
        public int numOfEmployees { get; set; } 
    }
}
