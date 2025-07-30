using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotel_project.View.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowUsers();    
        }
        private void ShowUsers()
        {
            string Query = "select * from UserTbl";
            UserGV.DataSource = Con.GetData(Query);
            UserGV.DataBind();

            if (UserGV.HeaderRow != null) 
            {
                UserGV.HeaderRow.Cells[1].Text = "NO.";
                UserGV.HeaderRow.Cells[2].Text = "User Name";
                UserGV.HeaderRow.Cells[3].Text = "Mobile";
                UserGV.HeaderRow.Cells[4].Text = "Gender";
                UserGV.HeaderRow.Cells[5].Text = "Email";
                UserGV.HeaderRow.Cells[6].Text = "Password";
            }                
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = UNameTb.Value;
                string UserMobileNumber = MNumberTb.Value;
                string UserGender = GenderTb.SelectedValue;
                string EmailAddress = EAddressTb.Value;
                string UserPassword = PasswordTb.Value;
                string Query = "insert into UserTbl values('{0}', '{1}', '{2}', '{3}', '{4}')";
                Query = string.Format(Query, UserName, UserMobileNumber, UserGender, EmailAddress, UserPassword);
                Con.setData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User is added!!!";
                UNameTb.Value = "";
                MNumberTb.Value = "";
                GenderTb.SelectedIndex = -1;
                EAddressTb.Value = "";
                PasswordTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
        int key = 0;
        protected void UserGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(UserGV.SelectedRow.Cells[1].Text);
            UNameTb.Value = UserGV.SelectedRow.Cells[2].Text;
            MNumberTb.Value = UserGV.SelectedRow.Cells[3].Text;
            GenderTb.SelectedValue = UserGV.SelectedRow.Cells[4].Text;
            EAddressTb.Value = UserGV.SelectedRow.Cells[5].Text;
            PasswordTb.Value = UserGV.SelectedRow.Cells[6].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = UNameTb.Value;
                string UserMobileNumber = MNumberTb.Value;
                string UserGender = GenderTb.SelectedValue;
                string EmailAddress = EAddressTb.Value;
                string UserPassword = PasswordTb.Value;
                string Query = "update UserTbl set UserName = '{0}', UserMobileNumber = '{1}', UserGender = '{2}', EmailAddress = '{3}', UserPassword = '{4}' where UserId = '{5}'";
                Query = string.Format(Query, UserName, UserMobileNumber, UserGender, EmailAddress, UserPassword, UserGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User is updated!!!";
                UNameTb.Value = "";
                MNumberTb.Value = "";
                GenderTb.SelectedIndex = -1;
                EAddressTb.Value = "";
                PasswordTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "delete from UserTbl where UserId = '{0}'";
                Query = string.Format(Query, UserGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowUsers();
                ErrMsg.InnerText = "User is deleted!!!";
                UNameTb.Value = "";
                MNumberTb.Value = "";
                GenderTb.SelectedIndex = -1;
                EAddressTb.Value = "";
                PasswordTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}