using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BinhLuanBLL
    {
        BinhLuanDAL bl = new BinhLuanDAL();
        public List<BinhLuanDTO> getAllComments(int macv)
        {
            return bl.getAllComments(macv);
        }

        public void addComment(int manv, int macv, string bln)
        {
            BinhLuanDTO cmt = new BinhLuanDTO();
            cmt.manv = manv;
            cmt.macv = macv;
            cmt.binhluan = bln;
            bl.addComment(cmt);
        }
    }
}