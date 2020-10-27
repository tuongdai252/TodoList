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
    public partial class EditTask : System.Web.UI.Page
    {
        CongViecBLL cvBLL = new CongViecBLL();
        CongViecDTO cv = new CongViecDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HoTen"] == null)
            {
                Response.Redirect("~/GUI/login.aspx");
            }

            else if (string.IsNullOrWhiteSpace(Request.QueryString["taskid"]))
            {
                Response.Redirect("~/GUI/login.aspx");
            }
            /*else if (Session["Level"].ToString().Equals("0"))
            {
                Nv_Cv_BLL nvcv = new Nv_Cv_BLL();
                int countNVCV = nvcv.countEmp_Task(Int32.Parse(Session["Nv_Id"].ToString()), Int32.Parse(Request.QueryString["taskid"]));
                if (countNVCV == 0)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }*/
            else if (!IsPostBack)
            {
                loadTask();
                showPartners();
                loadPartnersChecked();
                loadFile();
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
        public void loadPartnersChecked()
        {
            List<Nv_Cv_DTO> nvcvDTO = new List<Nv_Cv_DTO>();
            Nv_Cv_BLL nvcvBLL = new Nv_Cv_BLL();
            nvcvDTO = nvcvBLL.GetAllPartners(getTaskIdFromUrl());
            foreach (var item in nvcvDTO)
            {
                foreach (ListItem item1 in choosePartners.Items)
                {
                    if (item.manv.ToString().Equals(item1.Value)) item1.Selected = true ;
                }
            }
            
        }
        protected int getTaskIdFromUrl()
        {
            int macv = -1;
            Int32.TryParse(Request.QueryString["taskid"], out macv);
            return macv;
        }
        protected void loadTask()
        {
            cv = cvBLL.getTask(getTaskIdFromUrl());
            txtTaskName.Text = cv.tieude;
            txtStartDate.Text = cv.ngaybatdau.ToString("yyyy-MM-dd");
            txtEndDate.Text = cv.ngayketthuc.ToString("yyyy-MM-dd");
            chooseStatus.Text = cv.trangthai;
            choosePrivacy.Text = cv.phamvi;

        }

        protected void btnEditTask_Click(object sender, EventArgs e)
        {
            cv.tieude = txtTaskName.Text;
            if(txtTaskName.Text == "")
            {
                txtFailure.EnableViewState = true;
                txtFailure.Text = "Tên công việc không được để trống !!!";
                txtTaskName.Focus();
                return;
            }
            cv.ngaybatdau = Convert.ToDateTime(txtStartDate.Text);
            cv.ngayketthuc = Convert.ToDateTime(txtEndDate.Text);
            cv.phamvi = choosePrivacy.Text;
            cv.trangthai = chooseStatus.Text;
            cv.macv = getTaskIdFromUrl();
            if (cv.ngaybatdau > cv.ngayketthuc)                                   // Rào lỗi ngày bắt đầu sau ngày kết thúc 
            {
                txtFailure.EnableViewState = true;
                txtFailure.Text = "Ngày tháng không hợp lệ !!!";
                txtStartDate.Focus();
                return;
            }
            else
            {
                cvBLL.UpdateTask(cv);                                                 //Update cv to CongViec table
                //Response.Redirect("~/Default.aspx");
            }

            updatePartner();
            updateFile();
            Response.Redirect("~/Default.aspx");
        }

        protected void updatePartner()
        {
            Nv_Cv_BLL nvcvBLL = new Nv_Cv_BLL();                                        // check partner có đc check hay ko để thêm/xóa trong DB
            List<Nv_Cv_DTO> nvcvDTO = nvcvBLL.GetAllPartners(getTaskIdFromUrl());
            foreach (var item in nvcvDTO)                                               // item duyet danh sach cac nv_cv DA CHECK
            {
                foreach (ListItem item1 in choosePartners.Items)                        // item1 duyet danh sach da duoc hien tren GUI
                {
                    if (item1.Selected && item.manv.ToString().Equals(item1.Value))
                    {
                        continue;
                    }
                    else if (item1.Selected && !item.manv.ToString().Equals(item1.Value))
                    {
                        Nv_Cv_DTO SelectedPartner = new Nv_Cv_DTO();
                        SelectedPartner.macv = getTaskIdFromUrl();
                        SelectedPartner.manv = Convert.ToInt32(item1.Value);
                        nvcvBLL.AddPartners(SelectedPartner);                   // Add partners to NV_CV table
                    }
                    else if (!item1.Selected && !item.manv.ToString().Equals(item1.Value))
                    {
                        continue;
                    }
                    else if (!item1.Selected && item.manv.ToString().Equals(item1.Value))
                    {
                        nvcvBLL.DeletePartner(Convert.ToInt32(item1.Value), getTaskIdFromUrl());
                    }
                }
            }
        }

        protected void loadFile()
        {
            List<TapTinDTO> ttDTO = new List<TapTinDTO>();
            TapTinBLL ttBLL = new TapTinBLL();
            ttDTO = ttBLL.GetAllFiles(getTaskIdFromUrl());
            foreach (var item in ttDTO)
            {
                FileName.Items.Add(item.taptin);
            }
            
        }
        protected void updateFile()
        {
            TapTinBLL ttBLL = new TapTinBLL();
            TapTinDTO ttDTO = new TapTinDTO();

            if (FileUploadTask.HasFiles)
            {
                foreach (HttpPostedFile fu in FileUploadTask.PostedFiles)
                {
                    FileUploadTask.SaveAs(Path.Combine(Server.MapPath("/UploadFile/"), fu.FileName));
                    ttDTO.taptin = fu.FileName;
                    ttDTO.macv = getTaskIdFromUrl();
                    ttBLL.AddFile(ttDTO);
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}