using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSVS.AutomatedTestCases.Common
{
    public class public_lineitem
    {
        public int id { get; set; }
        public int hid { get; set; }
        public string pms_id { get; set; }
        public int client_id { get; set; }
        public int patient_id { get; set; }
        public string date { get; set; }
        public string invoice_number { get; set; }
        public int pms_provider_id { get; set; }
        public int pms_service_id { get; set; }
        public int occurance { get; set; }
        public int quantity { get; set; }
        public double cost { get; set; }
        public string description { get; set; }
        public string date_modified { get; set; }
    }
}
