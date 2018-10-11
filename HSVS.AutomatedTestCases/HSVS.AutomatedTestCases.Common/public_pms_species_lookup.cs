using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSVS.AutomatedTestCases.Common
{
    public class public_pms_species_lookup
    {
        public int id { get; set; }
        public int hid { get; set; }
        public string handle { get; set; }
        public string descr { get; set; }
        public int vi_species_id { get; set; }
        public int prelim_vi_id { get; set; }
        public bool vi_is_final { get; set; }
        public string text { get; set; }
        public bool do_not_display { get; set; }
        public DateTime date_added { get; set; }

    }
}
