using HSVS.AutomatedTestCases.BusinessLogic;
using HSVS.AutomatedTestCases.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HSVS.AutomatedTestCases
{
    class Program
    {
        public static void Main(string[] args)
        {
            LogFileHelper log = new LogFileHelper();
            string message = "Program Initiated";
            log.WriteToFile(message);
            Console.WriteLine("Enter your Option");
            Console.WriteLine("1. Load Functions from Path");
            Console.WriteLine("2. Load Table data");
            Console.WriteLine("3. Custom Query");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    LoadScripts();
                    break;
                case "2":
                    LoadTables();
                    break;
                case "3":
                    ExecuteCustomQuery();
                    break;

            }

            message = "Program end";
            log.WriteToFile(message);
        }
        public static void ExecuteCustomQuery()
        {
            Console.WriteLine("Enter Custom Query");
            //string myQuery = "select * from subscription.get_clinic_active_subscriptions(2882)";
            var myQuery = Console.ReadLine();
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();
            if (!string.IsNullOrEmpty(myQuery))
            {
                objBusiness.MyCustomQuery(myQuery);
            }
            else
            {
                ExecuteCustomQuery();
            }
        }
        public static void LoadScripts()
        {
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();
            LogFileHelper logger = new LogFileHelper();
            try
            {
                string path = @"D:\AccionLabs\Help\LocalDB\Functions";
                foreach (string fileName in Directory.GetFiles(path))
                {
                    //GET EACH FILE
                    var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                    {
                        string functionContent = streamReader.ReadToEnd();
                        if (!string.IsNullOrEmpty(functionContent))
                        {
                            //SEND FILENAME AND FILECONTENT FOR EACH FILE
                            objBusiness.CreateFunctionfromFile(fileName, functionContent);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                logger.WriteToFile("LoadScripts method exception : " + ex.Message);
            }
        }
        public static void LoadTables()
        {
            LogFileHelper logger = new LogFileHelper();
            BusinessLogicLayer objBusiness = new BusinessLogicLayer();
            try
            {
                string hid = "1074,2882";
                string[] tableswithoutHID = { "country_lookup", "campaign.campaign_program", "campaign.campaign_segment", "campaign.campaign_sequence", "campaign.campaign_versions", "campaign.emailtracking_status_lookup", "locale", "localization", "pms", "timezone", "vi_breed_lookup", "vi_client_patient_code_lookup", "vi_gender_lookup", "vi_li_lookup", "vi_species_lookup" };

                string[] tableswithHID = { "campaign.campaign_email_contact_tracking", "campaign.campaign_postal_contact_tracking", "campaign.crecap_email_tracking", "campaign.crecap_partner_vs_mapping", "campaign.dental_compliance_hids", "public.appointment", "public.client", "hospital_load_history", "lineitem", "patient", "pms_breed_lookup", "pms_client_code_lookup", "pms_gender_lookup", "pms_patient_code_lookup", "pms_provider_lookup", "pms_species_lookup", "working.campaign_contact_targets" };

                #region INSERT TABLES WITHOUT HOSPITAL ID

                for (var i = 0; i < tableswithoutHID.Length; i++)
                {
                    logger.WriteToFile("Getting data for the table : " + tableswithoutHID[i]);
                    objBusiness.GetDatafromQueryandInsert("select * from " + tableswithoutHID[i] + ";", tableswithoutHID[i]);
                }
                #endregion

                #region INSERT HOSPITAL TABLE

                logger.WriteToFile("Getting data for the table : hospital");
                objBusiness.GetDatafromQueryandInsert("select * from public.hospital where id IN (" + hid + ")", "public.hospital");
                #endregion

                #region INSERT TABLES WITH HOSPITAL ID


                for (var i = 0; i < tableswithHID.Length; i++)
                {
                    logger.WriteToFile("Getting data for the table : " + tableswithHID[i]);
                    objBusiness.GetDatafromQueryandInsert("select * from " + tableswithHID[i] + " where hid IN (" + hid + ")", tableswithHID[i]);
                }
                #endregion
            }
            catch (Exception ex)
            {
                logger.WriteToFile("LoadTables method exception : " + ex.Message);
            }
        }
    }
}
