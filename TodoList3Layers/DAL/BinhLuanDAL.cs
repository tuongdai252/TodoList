using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    class BinhLuanDAL
    {
        public List<BinhLuanDTO> getAllComments(int macv)
        {
            List<BinhLuanDTO> data = new List<BinhLuanDTO>();
            string query = "SELECT bl.*, nv.nv_hoten " +
                "FROM BinhLuan bl JOIN NhanVien nv ON bl.nv_id = nv.nv_id " +
                "WHERE cv_id = " + macv + " ORDER BY cmt_id desc";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    BinhLuanDTO bl = new BinhLuanDTO();
                    bl.mabl = reader.GetInt32(0);
                    bl.manv = reader.GetInt32(1);
                    bl.macv = reader.GetInt32(2);
                    bl.binhluan = reader.GetString(3);
                    bl.hoten = reader.GetString(4);
                    data.Add(bl);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }

        public void addComment(BinhLuanDTO bl)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "INSERT INTO BinhLuan (nv_id, cv_id, cmt_noidung) VALUES (@manv, @macv, @binhluan)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@manv", bl.manv);
            cmd.Parameters.AddWithValue("@macv", bl.macv);
            cmd.Parameters.AddWithValue("@binhluan", bl.binhluan);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteComment(string mabl)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM BinhLuan WHERE mabl = " + mabl;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteComments(int macv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM BinhLuan WHERE cv_id = " + macv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
