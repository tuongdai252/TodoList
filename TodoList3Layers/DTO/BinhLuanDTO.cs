using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BinhLuanDTO
    {
        public int mabl { get; set; }
        public int manv { get; set; }
        public int macv { get; set; }
        public string hoten { get; set; }
        public string binhluan { get; set; }

        public BinhLuanDTO() { }
        public BinhLuanDTO(int manv, int macv, String binhluan)
        {
            this.manv = manv;
            this.macv = macv;
            this.binhluan = binhluan;
        }
    }
}
