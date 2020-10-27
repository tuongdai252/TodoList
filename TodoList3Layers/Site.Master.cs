using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TodoList3Layers
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["HoTen"] != null)
                login_name.Text = Session["HoTen"].ToString();
        }
        /*protected void btn_Logout(object sender, EventArgs e)
        {hay đặt tên giống bên  m đi
            //MainContent.FindControl("btnLogout")
            Session.Clear();
            //Response.Redirect("~/login.aspx");
        }*/
        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }
    }
}
