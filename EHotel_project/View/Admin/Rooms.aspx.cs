using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotel_project.View.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowRooms();
            GetCategories();
        }
        private void ShowRooms()
        {
            string Query = "select * from RoomTbl";
            RoomsGV.DataSource = Con.GetData(Query);
            RoomsGV.DataBind();
            RoomsGV.HeaderRow.Cells[1].Text = "NO.";
            RoomsGV.HeaderRow.Cells[2].Text = "Name";
            RoomsGV.HeaderRow.Cells[3].Text = "Category";
            RoomsGV.HeaderRow.Cells[4].Text = "Location";
            RoomsGV.HeaderRow.Cells[5].Text = "Price";
            RoomsGV.HeaderRow.Cells[6].Text = "Mark";
            RoomsGV.HeaderRow.Cells[7].Text = "Status";
        }
        private void GetCategories() 
        {
            string Query = "select * from CategoryTbl";
            if (!Page.IsPostBack)
            {
                RTypeTb.DataTextField = Con.GetData(Query).Columns["TypeName"].ToString();
                RTypeTb.DataValueField = Con.GetData(Query).Columns["TypeId"].ToString();
                RTypeTb.DataSource = Con.GetData(Query);
                RTypeTb.DataBind();
            }          
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RoomName = RNameTb.Value;
                string RoomType = RTypeTb.SelectedValue.ToString();
                string RoomLocation = RLocationTb.Value;
                string RoomPrice = RPriceTb.Value;
                string RoomMark = RMarkTb.Value;
                string Status = "Free";
                string Query = "insert into RoomTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                Query = string.Format(Query, RoomName, RoomType, RoomLocation, RoomPrice, RoomMark, Status);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room is added!!!";
                RNameTb.Value = "";
                RTypeTb.SelectedIndex = -1;
                RLocationTb.Value = "";
                RPriceTb.Value = "";
                RMarkTb.Value = "";
            }
            catch (Exception Ex)
            { 
                ErrMsg.InnerText = Ex.Message;
            }
        }
        int key = 0;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RNameTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            RTypeTb.SelectedValue = RoomsGV.SelectedRow.Cells[3].Text;
            RLocationTb.Value = RoomsGV.SelectedRow.Cells[4].Text;
            RPriceTb.Value = RoomsGV.SelectedRow.Cells[5].Text;
            RMarkTb.Value = RoomsGV.SelectedRow.Cells[6].Text;
            StatusTb.SelectedValue = RoomsGV.SelectedRow.Cells[7].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string RoomName = RNameTb.Value;
                string RoomType = RTypeTb.SelectedValue.ToString();
                string RoomLocation = RLocationTb.Value;
                string RoomPrice = RPriceTb.Value;
                string RoomMark = RMarkTb.Value;
                string Status = StatusTb.SelectedValue.ToString();
                string Query = "update RoomTbl set RoomName = '{0}', RoomType = '{1}', RoomLocation = '{2}', RoomPrice = '{3}', RoomMark = '{4}', Status = '{5}' where RoomId = '{6}'";
                Query = string.Format(Query, RoomName, RoomType, RoomLocation, RoomPrice, RoomMark, Status, RoomsGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room is updated!!!";
                RNameTb.Value = "";
                RTypeTb.SelectedIndex = -1;
                RLocationTb.Value = "";
                RPriceTb.Value = "";
                RMarkTb.Value = "";
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
                string Query = "delete from RoomTbl where RoomId = '{0}'";
                Query = string.Format(Query, RoomsGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room is deleted!!!";
                RNameTb.Value = "";
                RTypeTb.SelectedIndex = -1;
                RLocationTb.Value = "";
                RPriceTb.Value = "";
                RMarkTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}