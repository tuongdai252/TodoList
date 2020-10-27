using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVienDTO
    {
        public int manv { get; set; }
        public string hoten { get; set; }
        public string gioitinh { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string sdt { get; set; }
        public int level { get; set; }

        public NhanVienDTO() { }
        public NhanVienDTO(String hoten, String password, String gioitinh, String email, String sdt, int level)
        {
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.email = email;
            this.password = password;
            this.sdt = sdt;
            this.level = level;
        }
    }
}
