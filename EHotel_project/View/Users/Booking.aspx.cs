using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotel_project.View.Users
{
    public partial class Booking : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowRooms();
            ShowBooks();
        }
        private void ShowRooms()
        {
            String St = "Free";
            string Query = "select RoomId as Id, RoomName as Name, RoomType as Types, RoomPrice as Price, Status as Status from RoomTbl where Status = '"+St+"'";
            RoomsGV.DataSource = Con.GetData(Query);
            RoomsGV.DataBind();
            RoomsGV.HeaderRow.Cells[1].Text = "NO.";
            RoomsGV.HeaderRow.Cells[2].Text = "Name";
            RoomsGV.HeaderRow.Cells[3].Text = "Category";
            //RoomsGV.HeaderRow.Cells[4].Text = "Location";
            RoomsGV.HeaderRow.Cells[4].Text = "Price";
            //RoomsGV.HeaderRow.Cells[6].Text = "Mark";
            RoomsGV.HeaderRow.Cells[5].Text = "Status";
        }
        private void ShowBooks()
        {
            string Query = "select * from BookTbl";
            BookingGV.DataSource = Con.GetData(Query);
            BookingGV.DataBind();
            BookingGV.HeaderRow.Cells[1].Text = "Booking NO.";
            BookingGV.HeaderRow.Cells[2].Text = "Booking Date";
            BookingGV.HeaderRow.Cells[3].Text = "Room No.";
            //RoomsGV.HeaderRow.Cells[4].Text = "Location";
            BookingGV.HeaderRow.Cells[4].Text = "User ID";
            //RoomsGV.HeaderRow.Cells[6].Text = "Mark";
            BookingGV.HeaderRow.Cells[5].Text = "Date-In";
            BookingGV.HeaderRow.Cells[6].Text = "Date-Out";
            BookingGV.HeaderRow.Cells[7].Text = "Amount";
        }
        int key = 0;
        int days = 1;
        protected void RoomsGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(RoomsGV.SelectedRow.Cells[1].Text);
            RNameTb.Value = RoomsGV.SelectedRow.Cells[2].Text;
            int cost = days * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
            PriceTb.Value = cost.ToString();
        }
        private void UpdateRoom() 
        {
            try
            {
                string st = "Booked";
                string Query = "update RoomTbl set Status = '{0}' where RoomId = '{1}'";
                Query = string.Format(Query, st, RoomsGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowRooms();
                ErrMsg.InnerText = "Room is updated!!!";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
        int Cost;
        private void GetCost()
        {
            DateTime DIn = Convert.ToDateTime(CheckinTb.Value);
            DateTime DOut = Convert.ToDateTime(CheckoutTb.Value);
            TimeSpan value = DOut - DIn;
            int Days = Convert.ToInt32(value.TotalDays);
            Cost = Days * Convert.ToInt32(RoomsGV.SelectedRow.Cells[4].Text);
        }

        protected void BookBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string BookRoom = RoomsGV.SelectedRow.Cells[1].Text;
                string BookDate = System.DateTime.Today.Date.ToString();
                string DateIn = CheckinTb.Value;
                string DateOut = CheckoutTb.Value;
                string Agent = Session["UserId"] as string;
                GetCost();
                int Amount = Convert.ToInt32(PriceTb.Value.ToString());
                string Query = "insert into BookTbl values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')";
                Query = string.Format(Query, BookDate, BookRoom, Agent, DateIn, DateOut, Cost);
                Con.setData(Query);
                UpdateRoom();
                ShowRooms();
                ShowBooks();
                ErrMsg.InnerText = "Room is booked!!!";
                RNameTb.Value = "";              
                PriceTb.Value = "";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}