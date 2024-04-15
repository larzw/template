namespace Dal;
using System.Data;
using System.Data.SqlClient;

public interface IPersonsDal
{
    public DataTable GetAll();
    public DataTable GetBy(int id);
    public int DeleteBy(int id);
    public DataTable CreateBy(DataTable dt);
    public int UpdateBy(DataTable dt);
}

public sealed class PersonsDal(string connectionString) : IPersonsDal
{
    private string ConnectionString { get; } = connectionString;

    public DataTable GetAll()
    {
        var dt = new DataTable();
        using (var con = new SqlConnection(this.ConnectionString))
        {
            con.Open();
            using (var da = new SqlDataAdapter(@"select * from Persons;", con))
            {
                da.Fill(dt);
            }
        }
        return dt;
    }

    public DataTable GetBy(int id)
    {
        var dt = new DataTable();
        using (var con = new SqlConnection(this.ConnectionString))
        {
            con.Open();
            using (var da = new SqlDataAdapter($"select * from Persons where Id = {id};", con))
            {
                da.Fill(dt);
            }
        }

        return dt;
    }

    public int DeleteBy(int id)
    {
        using (var con = new SqlConnection(this.ConnectionString))
        {
            con.Open();
            using (var cmd = new SqlCommand($"delete from Persons where Id = {id};", con))
            {
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public DataTable CreateBy(DataTable dt)
    {
        var ids = new List<int>();
        using (var con = new SqlConnection(this.ConnectionString))
        {
            con.Open();
            foreach (DataRow r in dt.Rows)
            {
                using (var cmd = new SqlCommand(@"insert into Persons output inserted.id values (@Name);", con))
                {
                    cmd.Parameters.AddWithValue("@Name", r["Name"]);
                    var id = (int)cmd.ExecuteScalar();
                    ids.Add(id);
                }
            }
        }

        // Now return the created entry
        var mergedDt = new DataTable();
        foreach (var id in ids)
        {
            var tempDt = this.GetBy(id);
            mergedDt.Merge(tempDt);
        }
        return mergedDt;
    }

    public int UpdateBy(DataTable dt)
    {
        var totalRowsUpdated = 0;
        using (var con = new SqlConnection(this.ConnectionString))
        {
            con.Open();
            foreach (DataRow r in dt.Rows)
            {
                using (var cmd = new SqlCommand(@"update Persons set Name = @Name where Id = @Id;", con))
                {
                    cmd.Parameters.AddWithValue("@Id", r["Id"]);
                    cmd.Parameters.AddWithValue("@Name", r["Name"]);
                    totalRowsUpdated += cmd.ExecuteNonQuery();
                }
            }
        }
        return totalRowsUpdated;
    }
}
