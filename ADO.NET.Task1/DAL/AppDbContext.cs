using System.Data.SqlClient;
using System.Data;

namespace ADO.NET.Task1.DAL;

public static class AppDbContext
{
    static readonly string connectionString = "server=Ruhel\\SQLEXPRESS;database=ADOTask1;trusted_connection=true;integrated security=true";
    static SqlConnection connection = new SqlConnection(connectionString);

    public static int NonQueryExecute(string command)
    {
        int result = 0;
        try
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(command, connection);
            result = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return result;
    }
    public static DataTable QueryExecute(string query)
    {
        DataTable dt = new DataTable();

        try
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

            adapter.Fill(dt);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return dt;
    }


}
