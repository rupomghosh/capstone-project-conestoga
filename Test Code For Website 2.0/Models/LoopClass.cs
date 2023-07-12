using System.Data.SqlClient;

namespace Test_Code_For_Website_2._0.Models
{
    public class LoopClass
    {
        public int Id { get; set; }

        public int SerialNumber { get; set; }

        public string? TechName { get; set; }
    
    
        public int SaveData()
        {
            SqlConnection con = new SqlConnection("Server=localhost;Database=TestLoopDatabase;Trusted_Connection=True;MultipleActiveResultSets=true; Integrated Security=True; TrustServerCertificate=True;");
            string query = "INSERT INTO LoopClass(SerialNumber, TechName) " +
                "values ('" + SerialNumber + "', '" + TechName + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }

    

}
