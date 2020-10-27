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
    public class TapTinBLL
    {
        TapTinDAL tt = new TapTinDAL();
        public void AddFile(TapTinDTO ttDTO)
        {
            tt.addFile(ttDTO);
        }
        public List<TapTinDTO> GetAllFiles(int macv)
        {
            return tt.getAllFiles(macv);
        }
    }
}