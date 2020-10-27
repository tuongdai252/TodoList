using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CongViecDTO
    {
        public int macv { get; set; }
        public string tieude { get; set; }
        public DateTime ngaybatdau { get; set; }
        public DateTime ngayketthuc { get; set; }
        public string trangthai { get; set; }
        public string phamvi { get; set; }

        public CongViecDTO() { }
        public CongViecDTO(String tieude, DateTime ngaybatdau, DateTime ngayketthuc, String trangthai, String phamvi)
        {
            this.tieude = tieude;
            this.ngaybatdau = ngaybatdau;
            this.ngayketthuc = ngayketthuc;
            this.trangthai = trangthai;
            this.phamvi = phamvi;
        }

        public string nbdToString()
        {
            return ngaybatdau.Year.ToString() + "-" + ngaybatdau.Month.ToString() + "-" + ngaybatdau.Day.ToString();
        }
        public string nktToString()
        {
            return ngayketthuc.Year.ToString() + "-" + ngayketthuc.Month.ToString() + "-" + ngayketthuc.Day.ToString();
        }
    }
}
