using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nv = new NhanVienDAL();

        public List<NhanVienDTO> getAllEmployees()
        {
            return nv.getAllEmployees();
        }

        public int CheckLogin(string mail, string pass)
        {
            NhanVienDTO nva = new NhanVienDTO();
            nva = GetNhanVien(mail);
            if (nva.password == pass)
            {
                return nva.level;
            }
            else return -1;
        }

        public NhanVienDTO GetNhanVien(string email)
        {
            return nv.GetNhanVien(email);
        }

        public int getID(string mail)
        {
            return GetNhanVien(mail).manv;
        }
        public string getName(string mail)
        {
            return GetNhanVien(mail).hoten;
        }
        public List<NhanVienDTO> GetPartners(string hoten) // truyền vào họ tên nhân viên ko muốn liệt kê trong ds partners (là người đang thêm task)
        {
            return nv.getPartners(hoten);
        }
        public List<NhanVienDTO> getPartners_Task(int macv, int manv)
        {
            return nv.getPartners_Task(macv, manv);
        }
    }
}