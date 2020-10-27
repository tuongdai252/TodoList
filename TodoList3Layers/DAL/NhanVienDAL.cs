using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Ajax.Utilities;

namespace DAL
{
    class NhanVienDAL
    {
        public List<NhanVienDTO> getAllEmployees()
        {
            List<NhanVienDTO> data = new List<NhanVienDTO>();
            string query = "SELECT * FROM NhanVien WHERE nv_level = 0 ";
            SqlConnection con = new DatabaseConnection().connectDB();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.HasRows)
            {
                while (reader.Read())
                {
                    NhanVienDTO nv = new NhanVienDTO();
                    nv.manv = reader.GetInt32(0);
                    nv.hoten = reader.GetString(1);
                    nv.email = reader.GetString(2);
                    //nv.password = reader.GetString(3);
                    nv.sdt = reader.GetString(4);
                    //nv.level = reader.GetInt32(5);
                    nv.gioitinh = reader.GetString(6);
                    data.Add(nv);
                }
                reader.NextResult();
            }
            con.Close();
            return data;
        }

        public void addEmployee(NhanVienDTO nv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "INSERT INTO NhanVien (nv_hoten, nv_mail, nv_pass, nv_sdt, nv_level, nv_gioitinh) " +
                           "VALUES (@hoten, @mail, @pass, @sdt, @level, @gioitinh)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@hoten", nv.hoten);
            cmd.Parameters.AddWithValue("@mail", nv.email);
            cmd.Parameters.AddWithValue("@pass", nv.password);
            cmd.Parameters.AddWithValue("@sdt", nv.sdt);
            cmd.Parameters.AddWithValue("@level", nv.level);
            cmd.Parameters.AddWithValue("@gioitinh", nv.gioitinh);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void updateEmployee(int manv, NhanVienDTO nv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "UPDATE NhanVien SET " +
                           "nv_hoten = " + nv.hoten +
                           ",nv_mail = " + nv.email +
                           ",nv_pass = " + nv.password +
                           ",nv_sdt = " + nv.sdt +
                           ",nv_level = " + nv.level +
                           ",nv_gioitinh = " + nv.gioitinh +
                          " WHERE manv = " + manv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteEmployee(int manv)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            string query = "DELETE FROM NhanVien WHERE manv = " + manv;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public int Login(String mail, String pass)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            try
            {
                string query = "Select count(*) from NhanVien where nv_mail = '" + mail + "' and nv_pass = '" + pass + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public NhanVienDTO GetNhanVien(string email)
        {
            NhanVienDTO nv = new NhanVienDTO();
            SqlConnection con = new DatabaseConnection().connectDB();
            try
            {
                string query = "Select * from NhanVien where nv_mail = '" + email + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nv.manv = reader.GetInt32(0);
                    nv.hoten = reader.GetString(1);
                    nv.email = reader.GetString(2);
                    nv.password = reader.GetString(3);
                    nv.sdt = reader.GetString(4);
                    nv.level = reader.GetInt32(5);
                    nv.gioitinh = reader.GetString(6);
                }
                
            }
            catch (Exception ex) { throw ex; }
            return nv;
        }
        
        public int getLevel(string mail, string pass)
        {
            SqlConnection con = new DatabaseConnection().connectDB();
            try
            {
                string query = "Select nv_level from NhanVien where nv_mail = '" + mail + "' and nv_pass = '" + pass + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                return a;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public List<NhanVienDTO> getPartners (string hoten) // truyen vao hoten nhan vien ko muon liet ke den
        {
            List<NhanVienDTO> data = new List<NhanVienDTO>();
            SqlConnection con = new DatabaseConnection().connectDB();
            try
            { 
                string query = "SELECT nv_id, nv_hoten FROM NhanVien where nv_hoten != N'" + hoten + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NhanVienDTO nv = new NhanVienDTO();
                        nv.manv = reader.GetInt32(0);
                        nv.hoten = reader.GetString(1);
                        data.Add(nv);
                    }
                    reader.NextResult();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public List<NhanVienDTO> getPartners_Task(int macv, int manv)
        {
            List<NhanVienDTO> data = new List<NhanVienDTO>();
            SqlConnection con = new DatabaseConnection().connectDB();
            try
            {
                string query = "SELECT nv.nv_id, nv.nv_hoten FROM NhanVien nv JOIN NV_CV nvcv ON nv.nv_id = nvcv.nv_id WHERE nvcv.cv_id = " + macv + " AND nvcv.nv_id != " + manv;
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NhanVienDTO nv = new NhanVienDTO();
                        nv.manv = reader.GetInt32(0);
                        nv.hoten = reader.GetString(1);
                        data.Add(nv);
                    }
                    reader.NextResult();
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
