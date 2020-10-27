using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Nv_Cv_DTO
    {
        public int manv { get; set; }
        public int macv { get; set; }
        public int hoanthanh { get; set; }

        public Nv_Cv_DTO() { }
        public Nv_Cv_DTO(int manv, int macv, int hoanthanh)
        {
            this.manv = manv;
            this.macv = macv;
            this.hoanthanh = hoanthanh;
        }
    }
}
