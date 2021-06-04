using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CustomerMaintenance
{
    public static class StateDB
    {
        //retrieve all states and return as a list of state objects
        public static List<State> GetStates()
        {
            List<State> states = new List<State>();
            SqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement = "SELECT StateCode, StateName from States order by StateName";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection );

            try
            {
                State s;
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while(reader.Read ())
                {
                    s = new State();
                    s.StateCode = reader["StateCode"].ToString();
                    s.StateName = reader["StateName"].ToString();
                    states.Add(s);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return states;
        }
    }
}
