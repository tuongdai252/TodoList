using Antlr.Runtime;
using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList3Layers.GUI
{
    public partial class AddTask : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HoTen"] == null)
            {
                Response.Redirect("~/GUI/login.aspx");

            }
            else if (Session["Level"].ToString().Equals("1"))
            {
                Response.Redirect("~/GUI/OthersListTask.aspx");
            }
            if (!IsPostBack)
            {
                showPartners();
            }
        }
        public void showPartners()
        {
            List<NhanVienDTO> data = new List<NhanVienDTO>();
            NhanVienBLL nv = new NhanVienBLL(); 
            data = nv.GetPartners(Session["HoTen"].ToString());
            choosePartners.DataSource = data;
            choosePartners.DataValueField = "manv";
            choosePartners.DataTextField = "hoten";
            choosePartners.DataBind();
        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            CongViecBLL cvBLL = new CongViecBLL();
            CongViecDTO cv = new CongViecDTO();
            cv.tieude = txtTaskName.Text;
            if (txtTaskName.Text == "")
            {
                txtFailure.EnableViewState = true;
                txtFailure.Text = Server.HtmlDecode("Tên công việc không được để trống !!!");
                txtTaskName.Focus();
                return;
            }
            /*if(txtStartDate.Text == "" || txtEndDate.Text == "")
            {
                txtFailure.Text = "Ngày tháng không đc bỏ trống !!!";
                txtStartDate.Focus();
            }*/
            cv.ngaybatdau = Convert.ToDateTime(txtStartDate.Text);
            cv.ngayketthuc = Convert.ToDateTime(txtEndDate.Text);
            cv.phamvi = choosePrivacy.Text;
            cv.trangthai = "Đang làm";
            if (cv.ngaybatdau > cv.ngayketthuc)                                   // Rào lỗi ngày bắt đầu sau ngày kết thúc 
            {
                txtFailure.EnableViewState = true;
                txtFailure.Text = "Ngày tháng không hợp lệ !!!";
                txtStartDate.Focus();
                return;
            }
            else
            {
                cvBLL.AddTask(cv);        
                
            }

            Nv_Cv_BLL partnerBLL = new Nv_Cv_BLL();
            Nv_Cv_DTO partner = new Nv_Cv_DTO();
            partner.macv = cvBLL.GetCurrentCongViecId();
            partner.manv = (int)Session["Nv_Id"];
            partner.hoanthanh = 0;
            partnerBLL.AddPartners(partner);                                   // Add data to NV_CV table

            foreach (ListItem item in choosePartners.Items)
            {
                if (item.Selected)
                {
                    Nv_Cv_DTO SelectedPartner = new Nv_Cv_DTO();
                    SelectedPartner.macv = cvBLL.GetCurrentCongViecId();
                    SelectedPartner.manv = Convert.ToInt32(item.Value);
                    SelectedPartner.hoanthanh = 0;
                    partnerBLL.AddPartners(SelectedPartner);                   // Add partners to NV_CV table
                }
            }

            TapTinBLL ttBLL = new TapTinBLL();             // Add File
            TapTinDTO tt = new TapTinDTO();

            if (FileUploadTask.HasFiles)
            {
                foreach (HttpPostedFile fu in FileUploadTask.PostedFiles)
                {
                    FileUploadTask.SaveAs(Path.Combine(Server.MapPath("/UploadFile/"), fu.FileName));
                    tt.taptin = fu.FileName;
                    tt.macv = cvBLL.GetCurrentCongViecId();
                    ttBLL.AddFile(tt);
                }
            }
            //Response.Write("<script language='javascript'>window.alert('Thêm thành công !!!');window.location='../Default.aspx';</script>");
            Response.Redirect("~/Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}