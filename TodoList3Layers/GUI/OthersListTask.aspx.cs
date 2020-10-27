using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TodoList3Layers.GUI
{
    public partial class OthersListTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HoTen"] == null)
            {
                Response.Redirect("~/GUI/login.aspx");
            }
            else
            {
                NhanVienBLL nv = new NhanVienBLL();
                gridListEmp.DataSource = nv.getAllEmployees();
                gridListEmp.DataBind();
            }
        }
        protected void Select_Btn(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx?empid=" + gridListEmp.SelectedRow.Cells[1].Text, false);
        }
        protected void gridListTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = "Mã nhân viên";
                e.Row.Cells[2].Text = "Tên nhân viên";
                e.Row.Cells[3].Text = "Giới tính";
                e.Row.Cells[4].Text = "Mail";
                e.Row.Cells[5].Text = "Password";
                e.Row.Cells[6].Text = "Số điện thoại";
                e.Row.Cells[7].Text = "Level";
            }
        }
    }
}