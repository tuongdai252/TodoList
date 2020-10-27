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
    public class CongViecBLL
    {
        CongViecDAL cv = new CongViecDAL();

        public List<CongViecDTO> getAllTasks(int manv)
        {
            return cv.getAllTasks(manv);
        }
        public void AddTask(CongViecDTO cvDTO)
        {
            cv.addTask(cvDTO);
        }
        public int GetCurrentCongViecId()
        {
            return cv.getCurrentCongViecId();
        }
        public void UpdateTask(CongViecDTO cvDTO)
        {
            cv.updateTask(cvDTO);
        }
        public List<CongViecDTO> getAllTasks_Status(int manv, string trangthai)
        {
            return cv.getAllTasks_Status(manv, trangthai);
        }

        public List<CongViecDTO> getAllTasks_Late(int manv)
        {
            return cv.getAllTasks_Late(manv);
        }

        public List<CongViecDTO> getAllTasks_Name(int manv, string tieude)
        {
            return cv.getAllTasks_Name(manv, tieude);
        }

        public List<CongViecDTO> getAllTasks_Time(int manv, string tgbd, string tgkt)
        {
            return cv.getAllTasks_Time(manv, tgbd, tgkt);
        }

        public List<CongViecDTO> getAllTasks_BeginTime(int manv, string tgbd)
        {
            return cv.getAllTasks_BeginTime(manv, tgbd);
        }

        public List<CongViecDTO> getAllTasks_EndTime(int manv, string tgkt)
        {
            return cv.getAllTasks_EndTime(manv, tgkt);
        }
        public CongViecDTO getTask(int macv)
        {
            return cv.getTask(macv);
        }
        public void deleteTask(int macv)
        {
            BinhLuanDAL bl = new BinhLuanDAL();
            TapTinDAL tt = new TapTinDAL();
            Nv_Cv_DAL nvcv = new Nv_Cv_DAL();
            bl.deleteComments(macv);
            tt.deleteFiles(macv);
            nvcv.deletePartners(macv);
            cv.deleteTask(macv);
        }
    }
}