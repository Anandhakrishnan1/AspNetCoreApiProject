using AspDotNetCoreApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspDotNetCoreApi.Repositories
{
    public class StateRepository
    {
        SqlConnection _sqlConnection;
        IConfiguration _configuration;
        public StateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=HobbyConnect;Integrated Security=True");
        }
        public void DeleteState(int Id)
        {
            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("spDeleteState", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pStateId", Id);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            _sqlConnection.Close();
        }

        public State GetStateById(int Id)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("spGetStateById " + Id, _sqlConnection);
            da.Fill(ds, "States");
            DataRow Row = ds.Tables["States"].Rows[0];
            State state = new State
            {
                StateId = Int32.Parse(Row["StateId"].ToString()),
                StateName = Row["StateName"].ToString()
            };
            return state;
        }

        public List<State> GetStates()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("spGetStates", _sqlConnection);
            da.Fill(ds, "States");
            List<State> states = new List<State>();
            foreach (DataRow item in ds.Tables["States"].Rows)
            {
                State state = new State
                {
                    StateId = Int32.Parse(item["StateId"].ToString()),
                    StateName = item["StateName"].ToString()
                };
                states.Add(state);
            }
            return states;
        }

        public void InsertState(State state)
        {
            _sqlConnection.Open();
            SqlCommand command = new SqlCommand("spInsertState", _sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@pStateName", state.StateName);
            command.ExecuteNonQuery();
            command.Dispose();
            _sqlConnection.Close();
        }

        public void UpdateState(State state)
        {
            _sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("spUpdateState", _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pStateId", state.StateId);
            cmd.Parameters.AddWithValue("@pStateName", state.StateName);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            _sqlConnection.Close();
        }
    }
}
