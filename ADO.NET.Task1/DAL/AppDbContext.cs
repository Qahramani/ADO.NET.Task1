using System.Data.SqlClient;
using System.Data;

namespace ADO.NET.Task1.DAL;

public class AppDbContext
{
    static readonly string connectionString = "server=Ruhel\\SQLEXPRESS;database=ADOTask1;trusted_connection=true;integrated security=true";
    SqlConnection connection = new SqlConnection(connectionString);

    public int NonQueryExecute(string command)
    {
        connection.Open();
        SqlCommand cmd = new SqlCommand(command, connection);
        int result = cmd.ExecuteNonQuery();
        connection.Close();
        return result;
    }
    public DataTable QueryExecute(string query)
    {
        connection.Open();
        SqlDataAdapter adapter = new SqlDataAdapter(query,connection);

        DataTable dt = new DataTable();
        adapter.Fill(dt);
        connection.Close();
        return dt;
    }


}
