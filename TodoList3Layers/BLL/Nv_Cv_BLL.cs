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
    public class Nv_Cv_BLL
    {
        Nv_Cv_DAL nvcv = new Nv_Cv_DAL();
        public void AddPartners(Nv_Cv_DTO partner)
        {
            nvcv.addPartner(partner);
        }
        public List<Nv_Cv_DTO> GetAllPartners(int macv)
        {
            return nvcv.getAllPartners(macv);
        }
        /*public List<Nv_Cv_DTO> getAllPartners(int macv, int manv)
        {
            return nvcv.getAllPartners(macv);
        }*/
        public void DeletePartner(int manv, int macv)
        {
            nvcv.deletePartner(manv, macv);
        }
        public void addPartner(int manv, int macv)
        {
            Nv_Cv_DTO nvcva = new Nv_Cv_DTO();
            nvcva.manv = manv;
            nvcva.macv = macv;
            nvcva.hoanthanh = 0;
            nvcv.addPartner(nvcva);
        }
        public int countEmp_Task(int manv, int macv)
        {
            return nvcv.countEmp_Task(manv, macv);
        }
    }
}