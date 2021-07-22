using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Siparis_Programı
{
    public static class dbConnection
    {
        public static string srConnectionString = "server=localhost;database=RestaurantDb;Integrated Security=SSPI;";

        public static DataSet return_data_set(string srQuery, out string Message)
        {
            DataSet dSet = new DataSet();
            Message = "Success!";
            try
            {
                using (SqlConnection connection = new SqlConnection(srConnectionString))
                {
                    connection.Open();
                    SqlDataAdapter DA = new SqlDataAdapter(srQuery, connection);
                    DA.Fill(dSet);
                    connection.Close();
                }
                return dSet;
            }
            catch (Exception E)
            {
                Message = "Error happened." + E.Message;
                return dSet;
            }
        }
        public static void update_database(string srQuery, out string Message)
        {
            DataSet dSet = new DataSet();
            Message = "Success!";
            try
            {
                using (SqlConnection connection = new SqlConnection(srConnectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(srQuery, connection);
                    command.ExecuteNonQuery();
                    Message = "Success!";
                    connection.Close();
                }
            }
            catch (Exception E)
            {
                Message = "Error happened." + E.Message;
            }
        }

        public class cmdParameterType
        {
            public cmdParameterType(string _parameterName, object _objParam)
            {
                parameterName = _parameterName;
                objParam = _objParam;
            }

            public cmdParameterType()
            {

            }

            public string parameterName = "";
            public object objParam;
        }

        public static DataTable cmd_Select_DB(string srQuery, List<cmdParameterType> lstParameters)
        {
            DataTable dtTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(dbConnection.srConnectionString))
            using (SqlCommand command = new SqlCommand(srQuery, connection))
            {
                foreach (var vrPerParameter in lstParameters)
                {
                    command.Parameters.AddWithValue(vrPerParameter.parameterName, vrPerParameter.objParam);
                }

                connection.Open();

                dtTable.Load(command.ExecuteReader());
            }

            return dtTable;
        }

        public static int cmd_update_DB(string srQuery, List<cmdParameterType> lstParameters)
        {
            using (SqlConnection connection = new SqlConnection(dbConnection.srConnectionString))
            using (SqlCommand command = new SqlCommand(srQuery, connection))
            {
                foreach (var vrPerParameter in lstParameters)
                {
                    command.Parameters.AddWithValue(vrPerParameter.parameterName, vrPerParameter.objParam);
                }

                connection.Open();

                return command.ExecuteNonQuery();
            }
        }

    }
}

