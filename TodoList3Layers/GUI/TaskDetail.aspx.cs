using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList3Layers.GUI
{
    public partial class TaskDetail : System.Web.UI.Page
    {
        int macv = -1;
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
            else
            {
                macv = Int32.Parse(Request.QueryString["taskid"]);
                load_data();
            }
            if (Session["Level"].ToString().Equals("0") && string.IsNullOrWhiteSpace(Request.QueryString["empid"]) == false)
            {
                Nv_Cv_BLL nvcv = new Nv_Cv_BLL();
                int countNVCV = nvcv.countEmp_Task(Int32.Parse(Session["Nv_Id"].ToString()), Int32.Parse(Request.QueryString["taskid"]));
                string pvi = Server.HtmlDecode(lblPrivacy.Text);
                if (countNVCV == 0 && pvi.Equals("private"))
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void load_data()
        {
            CongViecBLL cv = new CongViecBLL();
            TapTinBLL tt = new TapTinBLL();
            BinhLuanBLL bl = new BinhLuanBLL();
            NhanVienBLL nvb = new NhanVienBLL();
            CongViecDTO cvdt = cv.getTask(macv);
            labelTitle.Text = cvdt.tieude;
            lblStartDate.Text = cvdt.ngaybatdau.ToString().Split(null)[0];
            lblEndDate.Text = cvdt.ngayketthuc.ToString().Split(null)[0];
            lblPrivacy.Text = cvdt.phamvi;
            lblStatus.Text = cvdt.trangthai;
            ListPartners.DataSource = nvb.getPartners_Task(macv, Int32.Parse(Session["Nv_id"].ToString()));
            ListPartners.DataTextField = "hoten";
            ListPartners.DataBind();
            FileName.DataSource = tt.GetAllFiles(macv);
            FileName.DataTextField = "taptin";
            FileName.DataBind();
            RptCmt.DataSource = bl.getAllComments(macv);
            RptCmt.DataBind();
        }

        protected void Edit_Btn(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/EditTask?taskid=" + macv, false);
        }

        protected void GoBack_Btn(object sender, EventArgs e)
        {
            Response.Redirect("~/Default", false);
        }

        protected void Comment_Btn(object sender, EventArgs e)
        {
            if (txtComment.Text != "")
            {
                BinhLuanBLL bl = new BinhLuanBLL();
                bl.addComment(Int32.Parse(Session["Nv_Id"].ToString()), macv, txtComment.Text.Replace("\r\n", "<br />"));
                txtComment.Text = "";
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}