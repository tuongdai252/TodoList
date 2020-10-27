using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;

namespace TodoList3Layers.GUI
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Level"] != null)
            {
                if (Session["Level"].ToString().Equals("1"))
                    Response.Redirect("~/GUI/OthersListTask.aspx");
                else if (Session["Level"].ToString().Equals("0"))
                    Response.Redirect("~/Default.aspx");
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            NhanVienBLL bl = new NhanVienBLL();
            string mail = txtEmail.Text;
            string pass = txtPassword.Text;
            int kq = bl.CheckLogin(mail, pass);
            if (kq == 1) // 1 là admin
            {
                Session["HoTen"] = bl.getName(mail);
                Session["Level"] = 1; //admin
                Session["Nv_Id"] = bl.getID(mail);
                Response.Redirect("~/GUI/OthersListTask.aspx");
            }   
            else if(kq == 0) // 0 là nhanVien
            {
                Session["HoTen"] = bl.getName(mail);
                Session["Level"] = 0; // nhanVien
                Session["Nv_Id"] = bl.getID(mail);
                Response.Redirect("~/Default.aspx");
            }    
            else
            {
                FailureText.EnableViewState = true;
                FailureText.Text = "Vui lòng nhập đúng Email hoặc Password";
            }
        }
    }
}