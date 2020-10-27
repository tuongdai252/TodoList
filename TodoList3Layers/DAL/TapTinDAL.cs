using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    class TapTinDAL
    {
        public List<TapTinDTO> getAllFiles(int macv)
        {
            List<TapTinDTO> data = new List<TapTinDTO>();
            string query = "SELECT * FROM TapTin WHERE cv_id = " + macv;
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    TapTinDTO tt = new TapTinDTO();
                    tt.matt = reader.GetInt32(0);
                    tt.taptin = reader.GetString(1);
                    //tt.macv = reader.GetInt32(2);
                    data.Add(tt);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }

        public void addFile(TapTinDTO tt)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "INSERT INTO TapTin (tt_ten, cv_id) VALUES (@taptin, @macv)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@taptin", tt.taptin);
            cmd.Parameters.AddWithValue("@macv", tt.macv);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteFile(string matt)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM TapTin WHERE matt = " + matt;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteFiles(int macv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM TapTin WHERE cv_id = " + macv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
