using System;
using System.Collections.Generic;
using System.Drawing.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Ajax.Utilities;

namespace TodoList3Layers
{
    public partial class _Default : Page
    {
        int manv = -1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Hoten"] == null)
            {
                Response.Redirect("~/GUI/login.aspx");
            }
            else if (Session["Level"].ToString().Equals("1") && string.IsNullOrWhiteSpace(Request.QueryString["empid"]))
            {
                Response.Redirect("~/GUI/OthersListTask.aspx");
            }
            else if (Session["Level"].ToString().Equals("1") && string.IsNullOrWhiteSpace(Request.QueryString["empid"]) == false)
            {
                manv = Int32.Parse(Request.QueryString["empid"]);
                LoadData();
                remindLate();
            }
            else if (Session["Level"].ToString().Equals("0") && string.IsNullOrWhiteSpace(Request.QueryString["empid"]) == false)
            {
                manv = Int32.Parse(Request.QueryString["empid"]);
                LoadData();
                remindLate();
                hide_private();
            }
            else
            {
                manv = Int32.Parse(Session["Nv_Id"].ToString());
                LoadData();
                remindLate();
            }
        }

        protected void LoadData()
        {
            if (Session["Level"].ToString().Equals("1"))
            {
                btnAddTask.Visible = false;
            }
            if (RadioBtnAll.Checked == true)
            {
                AllSelected(manv);
            }
            else if (RadioBtnCompleted.Checked == true)
            {
                CompletedSelected(manv);
            }
            else if (RadioBtnPending.Checked == true)
            {
                PendingSelected(manv);
            }
            else if (RadioBtnRejected.Checked == true)
            {
                RejectedSelected(manv);
            }
        }

        protected void AllSelected(int manv)
        {
            CongViecBLL cv = new CongViecBLL();
            gridListTask.DataSource = cv.getAllTasks(manv);
            gridListTask.DataBind();
        }

        protected void CompletedSelected(int manv)
        {
            CongViecBLL cv = new CongViecBLL();
            gridListTask.DataSource = cv.getAllTasks_Status(manv, "Hoàn thành");
            gridListTask.DataBind();
        }

        protected void PendingSelected(int manv)
        {
            CongViecBLL cv = new CongViecBLL();
            gridListTask.DataSource = cv.getAllTasks_Status(manv, "Đang làm");
            gridListTask.DataBind();
        }

        protected void RejectedSelected(int manv)
        {
            CongViecBLL cv = new CongViecBLL();
            gridListTask.DataSource = cv.getAllTasks_Late(manv);
            gridListTask.DataBind();
        }

        protected void Search_Btn(object sender, EventArgs e)
        {
            if (!txtSearch.Text.IsNullOrWhiteSpace())
            {
                CongViecBLL cv = new CongViecBLL();
                gridListTask.DataSource = cv.getAllTasks_Name(manv, txtSearch.Text);
                gridListTask.DataBind();
            }
        }

        protected void Filter_Btn(object sender, EventArgs e)
        {
            CongViecBLL cv = new CongViecBLL();
            if (txtStartDate.Text != "" && txtEndDate.Text != "") //Both selected
            {
                gridListTask.DataSource = cv.getAllTasks_Time(manv, txtStartDate.Text, txtEndDate.Text);
                gridListTask.DataBind();
            }
            else if (txtStartDate.Text == "" && txtEndDate.Text != "") //EndDate selected
            {
                gridListTask.DataSource = cv.getAllTasks_EndTime(manv, txtEndDate.Text);
                gridListTask.DataBind();
            }
            else if (txtStartDate.Text != "" && txtEndDate.Text == "") //StartDate selected
            {
                gridListTask.DataSource = cv.getAllTasks_BeginTime(manv, txtStartDate.Text);
                gridListTask.DataBind();
            }
        }

        protected void AddTask_Btn(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/AddTask.aspx");
        }

        protected void Select_Btn(object sender, EventArgs e)
        {
            Response.Redirect("~/GUI/TaskDetail.aspx?taskid=" + gridListTask.SelectedRow.Cells[3].Text, false);
        }

        protected void Edit_Btn(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("~/GUI/EditTask.aspx?taskid=" + gridListTask.Rows[e.NewEditIndex].Cells[3].Text, false);
        }

        protected void Delete_Btn(object sender, GridViewDeleteEventArgs e)
        {
            CongViecBLL cv = new CongViecBLL();
            int deleteid = Int32.Parse(gridListTask.Rows[e.RowIndex].Cells[3].Text);
            cv.deleteTask(deleteid);
            Response.Redirect(Request.RawUrl);
        }

        protected void gridListTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Text = "Mã công việc";
                e.Row.Cells[4].Text = "Tên công việc";
                e.Row.Cells[5].Text = "Ngày bắt đầu";
                e.Row.Cells[6].Text = "Ngày kết thúc";
                e.Row.Cells[7].Text = "Trạng thái";
                e.Row.Cells[8].Text = "Phạm vi";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((Button)e.Row.Cells[2].Controls[0]).OnClientClick = "if(!confirm('Bạn có chắc chắn muốn xóa?')) return false;";
                e.Row.Cells[5].Text = e.Row.Cells[5].Text.Split(null)[0];
                e.Row.Cells[6].Text = e.Row.Cells[6].Text.Split(null)[0];
            }
            
        }
        

        
        protected void hide_private()
        {
            for (int i = 0; i < gridListTask.Rows.Count; i++)
            {
                gridListTask.Rows[i].Cells[1].Enabled = false;
                gridListTask.Rows[i].Cells[2].Enabled = false;
                string pvi = Server.HtmlDecode(gridListTask.Rows[i].Cells[8].Text);
                if (pvi == "Chỉ 1 mình tôi")
                {
                    gridListTask.Rows[i].Visible = false;
                }
            }
        }

        protected void remindLate()
        {
            for (int i = 0; i < gridListTask.Rows.Count; i++)
            {
                DateTime nkt = DateTime.ParseExact(gridListTask.Rows[i].Cells[6].Text, "MM/dd/yyyy", null);
                string tthai = Server.HtmlDecode(gridListTask.Rows[i].Cells[7].Text);
                if (nkt == DateTime.Today && tthai == "Đang làm")
                {
                    gridListTask.Rows[i].BackColor = System.Drawing.Color.OrangeRed;
                    gridListTask.Rows[i].ForeColor = System.Drawing.Color.White;
                    gridListTask.Rows[i].Cells[7].Text = "Sắp hết hạn";
                }
                else if (nkt < DateTime.Today && tthai == "Đang làm")
                {
                    gridListTask.Rows[i].BackColor = System.Drawing.Color.OrangeRed;
                    gridListTask.Rows[i].ForeColor = System.Drawing.Color.White;
                    gridListTask.Rows[i].Cells[7].Text = "Trễ hạn";
                }
            }
        }
    }
}