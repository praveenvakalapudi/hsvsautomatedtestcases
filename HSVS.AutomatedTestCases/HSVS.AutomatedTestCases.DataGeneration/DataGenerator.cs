using HSVS.AutomatedTestCases.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSVS.AutomatedTestCases.DataGeneration
{
    public class DataGenerator
    {
        public List<public_lineitem> GenerateLineItem()
        {
            List<public_lineitem> lstLineItem = new List<public_lineitem>();
            public_lineitem pl = null;
            // GENERATE DATA
            #region LINEITEM 1
            pl = new public_lineitem();
            pl.id = 1;
            pl.hid = 2882;
            pl.pms_id = "753:6779";
            pl.client_id = 96772283;
            pl.patient_id = 164445456;
            pl.date = "2018-09-17";//TODAY
            pl.invoice_number = "";
            pl.pms_provider_id = 719307;
            pl.pms_service_id = 114811090;
            pl.occurance = 1;
            pl.quantity = 1;
            pl.cost = 35;
            pl.description = "desc";
            pl.date_modified = "2018-09-17";
            lstLineItem.Add(pl);
            #endregion

            #region LINEITEM 2
            pl = new public_lineitem();
            pl.id = 2;
            pl.hid = 2882;
            pl.pms_id = "753:6779";
            pl.client_id = 96772284;
            pl.patient_id = 164445457;
            pl.date = "2018-09-16";//TODAY
            pl.invoice_number = "";
            pl.pms_provider_id = 719307;
            pl.pms_service_id = 114811090;
            pl.occurance = 1;
            pl.quantity = 1;
            pl.cost = 35;
            pl.description = "desc";
            pl.date_modified = "2018-09-17";
            lstLineItem.Add(pl);
            #endregion

            #region LINEITEM 3
            pl = new public_lineitem();
            pl.id = 3;
            pl.hid = 2882;
            pl.pms_id = "753:6779";
            pl.client_id = 96772285;
            pl.patient_id = 164445458;
            pl.date = "2018-09-15";//TODAY
            pl.invoice_number = "";
            pl.pms_provider_id = 719307;
            pl.pms_service_id = 114811090;
            pl.occurance = 1;
            pl.quantity = 1;
            pl.cost = 35;
            pl.description = "desc";
            pl.date_modified = "2018-09-17";
            lstLineItem.Add(pl);
            #endregion

            #region LINEITEM 4
            pl = new public_lineitem();
            pl.id = 4;
            pl.hid = 1074;
            pl.pms_id = "753:6779";
            pl.client_id = 96772286;
            pl.patient_id = 164445459;
            pl.date = "2018-09-14";//TODAY
            pl.invoice_number = "";
            pl.pms_provider_id = 719307;
            pl.pms_service_id = 114811090;
            pl.occurance = 1;
            pl.quantity = 1;
            pl.cost = 35;
            pl.description = "desc";
            pl.date_modified = "2018-09-17";
            lstLineItem.Add(pl);
            #endregion

            return lstLineItem;
        }

        public List<public_pms_species_lookup> GenerateSpeciesLookup()
        {
            List<public_pms_species_lookup> lst = new List<public_pms_species_lookup>();
            public_pms_species_lookup speciesLookup = null;
            try
            {
                speciesLookup = new public_pms_species_lookup();
            }
            catch (Exception ex)
            {
            }
            return lst;
        }

        
    }
}
