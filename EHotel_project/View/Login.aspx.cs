using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotel_project.View
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            Session["UserName"] = "";
            Session["UserId"] = "";
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Admin/Rooms.aspx");
            if (AdminCb.Checked)
            {
                if (UserTb.Value == "Admin" && PasswordTb.Value == "password")
                {
                    Session["UserName"] = "Admin";
                    Response.Redirect("Admin/Rooms.aspx");
                }
                else
                {
                    ErrMsg.InnerText = "Invalidate Admin!!!";
                }
            }
            else 
            {
                string Query = "select UserId, UserName, UserPassword from UserTbl where UserName = '{0}' and UserPassword = '{1}'";
                Query = string.Format(Query, UserTb.Value, PasswordTb.Value);
                DataTable dt = Con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    ErrMsg.InnerText = "Invalidate User!!!";
                }
                else
                {
                    Session["UserName"] = dt.Rows[0][1].ToString();
                    Session["UserId"] = dt.Rows[0][0].ToString();
                    Response.Redirect("Users/Booking.aspx");
                }
            }
        }
    }
}