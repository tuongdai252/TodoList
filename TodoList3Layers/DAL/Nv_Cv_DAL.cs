using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Nv_Cv_DAL
    {
        public List<Nv_Cv_DTO> getAllPartners(int macv)
        {
            List<Nv_Cv_DTO> data = new List<Nv_Cv_DTO>();
            string query = "SELECT nv_id FROM NV_CV WHERE cv_id = " + macv;
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    Nv_Cv_DTO nvcv = new Nv_Cv_DTO();
                    nvcv.manv = reader.GetInt32(0);
                    //nvcv.macv = reader.GetInt32(1);
                    //nvcv.hoanthanh = reader.GetInt32(2);
                    data.Add(nvcv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }
        public void addPartner(Nv_Cv_DTO nvcv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "INSERT INTO NV_CV (nv_id, cv_id) VALUES (@manv, @macv)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@manv", nvcv.manv);
            cmd.Parameters.AddWithValue("@macv", nvcv.macv);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /*public void updateFinished(int manv, int macv, int hoanthanh)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "UPDATE NV_CV SET hoanthanh = " + hoanthanh +
                          " WHERE nv_id = " + manv + " AND cv_id = " + macv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }*/

        public void deletePartner(int manv, int macv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM NV_CV WHERE nv_id = " + manv + " AND cv_id = " + macv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deletePartners(int macv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM NV_CV WHERE cv_id = " + macv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int countEmp_Task(int manv, int macv)
        {
            int count = 0;
            string query = "SELECT COUNT(*) FROM NV_CV WHERE nv_id = 12 AND cv_id = 8";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            con.Close();
            return count;
        }
    }
}
