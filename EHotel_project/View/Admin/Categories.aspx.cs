using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EHotel_project.View.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowCategories();
            LoginUser.InnerText = Session["UserName"] as string;
        }
        private void ShowCategories() 
        {
            string Query = "select TypeId as Id, TypeName as Type, TypeMark from CategoryTbl";
            CategoriesGV.DataSource = Con.GetData(Query);
            CategoriesGV.DataBind();
            CategoriesGV.HeaderRow.Cells[1].Text = "Serial Number";
            CategoriesGV.HeaderRow.Cells[2].Text = "Room Type";
            CategoriesGV.HeaderRow.Cells[3].Text = "Label";
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TypeName = RTNameTb.Value;
                string TypeMark = RMarkTb.Value;
                string Query = "insert into CategoryTbl values('{0}', '{1}')";
                Query = string.Format(Query, TypeName, TypeMark);
                Con.setData(Query);
                ShowCategories();
                ErrMsg.InnerText = "Room type is added!!!";
            }
            catch (Exception Ex) 
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
        int key = 0;
        protected void CategoriesGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = Convert.ToInt32(CategoriesGV.SelectedRow.Cells[1].Text);
            RTNameTb.Value = CategoriesGV.SelectedRow.Cells[2].Text;
            RMarkTb.Value = CategoriesGV.SelectedRow.Cells[3].Text;
        }
        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string TypeName = RTNameTb.Value;
                string TypeMark = RMarkTb.Value;
                string Query = "update CategoryTbl set TypeName = '{0}', TypeMark = '{1}' where TypeId = '{2}'";
                Query = string.Format(Query, TypeName, TypeMark, CategoriesGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowCategories();
                ErrMsg.InnerText = "Room type is updated!!!";
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
                string TypeName = RTNameTb.Value;
                string TypeMark = RMarkTb.Value;
                string Query = "delete from CategoryTbl where TypeId = '{0}'";
                Query = string.Format(Query, CategoriesGV.SelectedRow.Cells[1].Text);
                Con.setData(Query);
                ShowCategories();
                ErrMsg.InnerText = "Room type is deleted!!!";
            }
            catch (Exception Ex)
            {
                ErrMsg.InnerText = Ex.Message;
            }
        }
    }
}