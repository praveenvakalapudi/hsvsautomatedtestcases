using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;
using System.Data;
using HSVS.AutomatedTestCases.Logger;

namespace HSVS.AutomatedTestCases.Dao
{
    public class DataAccessLayer
    {
        public string _SourceConnection = Convert.ToString(ConfigurationManager.AppSettings["SOURCEDB"]);
        public string _DestinationConnection = Convert.ToString(ConfigurationManager.AppSettings["DESTINATIONDB"]);
        readonly NpgsqlConnection sourceConnServer;
        readonly NpgsqlConnection destinationConnServer;
        readonly LogFileHelper _logger;
        public DataAccessLayer()
        {
            sourceConnServer = new NpgsqlConnection(_SourceConnection);
            destinationConnServer = new NpgsqlConnection(_DestinationConnection);
            _logger = new LogFileHelper();
        }

        public DataTable GenericExecution_Source(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                string message = "SOURCE DB EXECUTION : SQL statement - " + sql;
                _logger.WriteToFile(message);

                if (sourceConnServer.State == ConnectionState.Closed)
                    sourceConnServer.Open();
                NpgsqlCommand command = sourceConnServer.CreateCommand();
                command.CommandText = sql;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, sourceConnServer);
                da.Fill(dt);
                sourceConnServer.Close();

                message = "SOURCE DB EXECUTION : SQL statement done";
                _logger.WriteToFile(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SOURCE DB EXECUTION Exception : SQL statement - " + ex.Message);
            }
            return dt;
        }

        public DataTable GenericExecution_Destination(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                string message = "DESTINATION DB EXECUTION : SQL statement - " + sql;
                _logger.WriteToFile(message);

                if (destinationConnServer.State == ConnectionState.Closed)
                    destinationConnServer.Open();
                NpgsqlCommand command = destinationConnServer.CreateCommand();

                command.CommandText = sql;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, destinationConnServer);
                da.Fill(dt);
                destinationConnServer.Close();

                message = "DESTINATION DB EXECUTION : SQL statement done";
                _logger.WriteToFile(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("DESTINATION DB EXECUTION : Exception - " + ex.Message);
            }
            return dt;
        }
    }

}
