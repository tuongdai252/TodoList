using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    class CongViecDAL
    {
        public List<CongViecDTO> getAllTasks(int manv)
        {
            List<CongViecDTO> data = new List<CongViecDTO>();
            string query = "SELECT * FROM CongViec cv JOIN NV_CV nvcv ON cv.cv_id = nvcv.cv_id " +
                "           WHERE nvcv.nv_id = " + manv;
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    CongViecDTO cv = new CongViecDTO();
                    cv.macv = reader.GetInt32(0);
                    cv.tieude = reader.GetString(1);
                    cv.ngaybatdau = reader.GetDateTime(2);
                    cv.ngayketthuc = reader.GetDateTime(3);
                    cv.phamvi = reader.GetString(5);
                    cv.trangthai = reader.GetString(4);
                    data.Add(cv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }

        public CongViecDTO getTask(int macv)
        {
            CongViecDTO cv = new CongViecDTO();
            string query = "SELECT * FROM CongViec WHERE cv_id = " + macv;
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cv.macv = reader.GetInt32(0);
                cv.tieude = reader.GetString(1);
                cv.ngaybatdau = reader.GetDateTime(2);
                cv.ngayketthuc = reader.GetDateTime(3);
                cv.phamvi = reader.GetString(5);
                cv.trangthai = reader.GetString(4);
            }
            con.Close();
            return cv;
        }
        public List<CongViecDTO> getAllTasks_Status(int manv, string trangthai)
        {
            List<CongViecDTO> data = new List<CongViecDTO>();
            string query = "SELECT * FROM CongViec cv JOIN NV_CV nvcv ON cv.cv_id = nvcv.cv_id " +
                "           WHERE nvcv.nv_id = " + manv + " AND cv.cv_trangthai = N'" + trangthai + "'";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    CongViecDTO cv = new CongViecDTO();
                    cv.macv = reader.GetInt32(0);
                    cv.tieude = reader.GetString(1);
                    cv.ngaybatdau = reader.GetDateTime(2);
                    cv.ngayketthuc = reader.GetDateTime(3);
                    cv.phamvi = reader.GetString(5);
                    cv.trangthai = reader.GetString(4);
                    data.Add(cv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }

        public List<CongViecDTO> getAllTasks_Time(int manv, string tgbd, string tgkt)
        {
            List<CongViecDTO> data = new List<CongViecDTO>();
            string query = "SELECT * FROM CongViec cv JOIN NV_CV nvcv ON cv.cv_id = nvcv.cv_id " +
                "           WHERE nvcv.nv_id = " + manv + " AND cv.cv_ngaybatdau >= '" + tgbd + "' AND cv.cv_ngayketthuc <= '" + tgkt + "'";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    CongViecDTO cv = new CongViecDTO();
                    cv.macv = reader.GetInt32(0);
                    cv.tieude = reader.GetString(1);
                    cv.ngaybatdau = reader.GetDateTime(2);
                    cv.ngayketthuc = reader.GetDateTime(3);
                    cv.phamvi = reader.GetString(5);
                    cv.trangthai = reader.GetString(4);
                    data.Add(cv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }

        public List<CongViecDTO> getAllTasks_Name(int manv, string tieude)
        {
            List<CongViecDTO> data = new List<CongViecDTO>();
            string query = "SELECT * FROM CongViec cv JOIN NV_CV nvcv ON cv.cv_id = nvcv.cv_id " +
                          "WHERE nvcv.nv_id = " + manv + " AND cv.cv_ten LIKE N'%" + tieude + "%'";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    CongViecDTO cv = new CongViecDTO();
                    cv.macv = reader.GetInt32(0);
                    cv.tieude = reader.GetString(1);
                    cv.ngaybatdau = reader.GetDateTime(2);
                    cv.ngayketthuc = reader.GetDateTime(3);
                    cv.phamvi = reader.GetString(5);
                    cv.trangthai = reader.GetString(4);
                    data.Add(cv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }
        public void addTask(CongViecDTO cv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "INSERT INTO CongViec (cv_ten, cv_ngaybatdau, cv_ngayketthuc, cv_trangthai, cv_phamvi) " +
                           "VALUES (@ten, Convert(datetime,@ngaybatdau,103), Convert(datetime,@ngayketthuc,103), @trangthai, @phamvi)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ten", cv.tieude);
            cmd.Parameters.AddWithValue("@ngaybatdau", cv.ngaybatdau);
            cmd.Parameters.AddWithValue("@ngayketthuc", cv.ngayketthuc);
            cmd.Parameters.AddWithValue("@trangthai", cv.trangthai);
            cmd.Parameters.AddWithValue("@phamvi", cv.phamvi);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateTask(CongViecDTO cv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "UPDATE CongViec SET " +
                           "cv_ten = N'" + cv.tieude + "'" +
                           ",cv_ngaybatdau = '" + cv.nbdToString() + "'" +
                           ",cv_ngayketthuc = '" + cv.nktToString() + "'" +
                           ",cv_trangthai = N'" + cv.trangthai + "'" +
                           ",cv_phamvi = N'" + cv.phamvi + "'" +
                          " WHERE cv_id = " + cv.macv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int getCurrentCongViecId()
        {
            int a = 0;
            SqlConnection con = new DatabaseConnection().connectDB();
            try
            {
                string query = "select IDENT_CURRENT('dbo.CongViec')";
                SqlCommand cmd = new SqlCommand(query, con);
                a = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex) { throw ex; }
            finally 
            {
                con.Close(); 
            }
            return a;
        }
        public List<CongViecDTO> getAllTasks_BeginTime(int manv, string tgbd)
        {
            List<CongViecDTO> data = new List<CongViecDTO>();
            string query = "SELECT * FROM CongViec cv JOIN NV_CV nvcv ON cv.cv_id = nvcv.cv_id " +
                "           WHERE nvcv.nv_id = " + manv + " AND cv.cv_ngaybatdau = '" + tgbd + "'";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    CongViecDTO cv = new CongViecDTO();
                    cv.macv = reader.GetInt32(0);
                    cv.tieude = reader.GetString(1);
                    cv.ngaybatdau = reader.GetDateTime(2);
                    cv.ngayketthuc = reader.GetDateTime(3);
                    cv.phamvi = reader.GetString(5);
                    cv.trangthai = reader.GetString(4);
                    data.Add(cv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }
        public List<CongViecDTO> getAllTasks_EndTime(int manv, string tgkt)
        {
            List<CongViecDTO> data = new List<CongViecDTO>();
            string query = "SELECT * FROM CongViec cv JOIN NV_CV nvcv ON cv.cv_id = nvcv.cv_id " +
                "           WHERE nvcv.nv_id = " + manv + " AND cv.cv_ngayketthuc = '" + tgkt + "'";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    CongViecDTO cv = new CongViecDTO();
                    cv.macv = reader.GetInt32(0);
                    cv.tieude = reader.GetString(1);
                    cv.ngaybatdau = reader.GetDateTime(2);
                    cv.ngayketthuc = reader.GetDateTime(3);
                    cv.phamvi = reader.GetString(5);
                    cv.trangthai = reader.GetString(4);
                    data.Add(cv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }
        public List<CongViecDTO> getAllTasks_Late(int manv)
        {
            List<CongViecDTO> data = new List<CongViecDTO>();
            string query = "SELECT * FROM CongViec cv JOIN NV_CV nvcv ON cv.cv_id = nvcv.cv_id " +
                "           WHERE nvcv.nv_id = " + manv + " AND cv.cv_ngayketthuc <= (SELECT GETDATE())";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    CongViecDTO cv = new CongViecDTO();
                    cv.macv = reader.GetInt32(0);
                    cv.tieude = reader.GetString(1);
                    cv.ngaybatdau = reader.GetDateTime(2);
                    cv.ngayketthuc = reader.GetDateTime(3);
                    cv.phamvi = reader.GetString(5);
                    cv.trangthai = reader.GetString(4);
                    data.Add(cv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }
        public void deleteTask(int macv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM CongViec WHERE cv_id = " + macv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
