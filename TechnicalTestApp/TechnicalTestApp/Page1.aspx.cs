using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TechnicalTestApp.Models;

namespace TechnicalTestApp
{
    public partial class Page1 : Page
    {
        InfoDbContext db = new InfoDbContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialTypeDataLoad();
                var type = db.Types.ToList();
                ddlType.DataSource = type;
                ddlType.DataValueField = "Value";
                ddlType.DataTextField = "Name";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("Select One", ""));
                ddlType.SelectedIndex = -1;
            }
        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            ShowErrorMessage();
            string title = txtTitle.Text.Trim();
            string address = txtAddress.Text.Trim();
            string type = ddlType.SelectedValue;
            string date = txtDate.Text.Trim();
            string time = txtTime.Text.Trim();
            string remarks = txtRemarks.Text.Trim();

            if (title == "" || date == "" || time == "")
            {
                ShowErrorMessage(true, "Title, Date and Time is required");
                return;
            }
            Clear();
            DataTable dt = new DataTable();
            if (ViewState["GridData"] != null)
                dt = (DataTable)ViewState["GridData"];
            else
            {
                dt.Columns.Add("Title");
                dt.Columns.Add("Address");
                dt.Columns.Add("Type");
                dt.Columns.Add("Date");
                dt.Columns.Add("Time");
                dt.Columns.Add("Remarks");
            }

            DataRow dr = dt.NewRow();
            dr["Title"] = title;
            dr["Address"] = address;
            dr["Type"] = type;
            dr["Date"] = date;
            dr["Time"] = time;
            dr["Remarks"] = remarks;

            dt.Rows.Add(dr);


            ViewState["GridData"] = dt;
            tblData.DataSource = dt;
            tblData.DataBind();
        }

        protected void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        private void SearchData()
        {
            string searchText = txtSearchBox.Text.Trim();
            DataTable dt = new DataTable();
            DataTable tblFiltered = null;
            if (ViewState["GridData"] != null)
                dt = (DataTable)ViewState["GridData"];
            try
            {
                tblFiltered = dt.AsEnumerable().Where(
                r => r.Field<string>("Title").ToLower().Contains(searchText.ToLower())
                 || r.Field<string>("Address").ToLower().Contains(searchText.ToLower())
                 || r.Field<string>("Type").ToLower().Contains(searchText.ToLower())
                 || r.Field<string>("Date").ToLower().Contains(searchText.ToLower())
                 || r.Field<string>("Time").ToLower().Contains(searchText.ToLower())
                 || r.Field<string>("Remarks").ToLower().Contains(searchText.ToLower())
                )
                .CopyToDataTable();
            }
            catch (Exception)
            {

            }

            tblData.DataSource = tblFiltered;
            tblData.DataBind();
        }

        private void ShowErrorMessage(bool isVisiable = false, string message = "")
        {
            divErrorMessage.Visible = isVisiable;
            lblErrorMessage.Text = message;
        }
        private void ShowSuccessMessage(bool isVisiable = false, string message = "")
        {
            divSuccessMessage.Visible = isVisiable;
            lblSuccessMessage.Text = message;
        }
        private void Clear()
        {
            txtTitle.Text = "";
            txtAddress.Text = "";
            ddlType.SelectedIndex = -1;
            txtDate.Text = "";
            txtTime.Text = "";
            txtRemarks.Text = "";
        }
        private void InitialTypeDataLoad()
        {
            if (db.Types.Count() == 0)
                db.Database.ExecuteSqlCommand("INSERT INTO Types(Value,Name) VALUES('Type 1','Type 1'),('Type 2','Type 2'),('Type 3','Type 3'),('Type 4','Type 4'),('Type 5','Type 5'),('Type 6','Type 6'),('Type 7','Type 7'),('Type 8','Type 8'),('Type 9','Type 9'),('Type 10','Type 10'),('Type 11','Type 11'),('Type 12','Type 12'),('Type 13','Type 13')");
        }

        protected void btnGridRemove_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button btnRemove = (System.Web.UI.WebControls.Button)sender;
            GridViewRow  row = (GridViewRow)btnRemove.Parent.Parent;
            string title = ((System.Web.UI.WebControls.Label)row.FindControl("txtGridTitle")).Text;
            string address = ((System.Web.UI.WebControls.Label)row.FindControl("txtGridAddress")).Text;
            string type = ((System.Web.UI.WebControls.Label)row.FindControl("txtGridType")).Text;
            string date = ((System.Web.UI.WebControls.Label)row.FindControl("txtGridDate")).Text;
            string time = ((System.Web.UI.WebControls.Label)row.FindControl("txtGridTime")).Text;
            string remarks = ((System.Web.UI.WebControls.Label)row.FindControl("txtGridRemarks")).Text;


            DataTable dt = new DataTable();
            if (ViewState["GridData"] != null)
                dt = (DataTable)ViewState["GridData"];
            try
            {
                DataRow  tblFiltered = dt.AsEnumerable().FirstOrDefault(
                r => r.Field<string>("Title").ToLower().Contains(title)
                 || r.Field<string>("Address").ToLower().Contains(address)
                 || r.Field<string>("Type").ToLower().Contains(type)
                 || r.Field<string>("Date").ToLower().Contains(date)
                 || r.Field<string>("Time").ToLower().Contains(time)
                 || r.Field<string>("Remarks").ToLower().Contains(remarks)
                );
                dt.Rows.Remove(tblFiltered);
                ViewState["GridData"] = dt;
                SearchData();
            }
            catch (Exception)
            {

            }
        }

        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            ShowSuccessMessage();
            ShowErrorMessage();
            DataTable dt = new DataTable();
            if (ViewState["GridData"] != null)
                dt = (DataTable)ViewState["GridData"];
            else
            {
                ShowErrorMessage(true, "No Data Available");
                return;
            }

            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    db.Informations.Add(new Information()
                    {
                        Title = row["Title"].ToString(),
                        Address = row["Address"].ToString(),
                        Type = row["Type"].ToString(),
                        Date = row["Date"].ToString(),
                        Time = row["Time"].ToString(),
                        Remarks = row["Remarks"].ToString()
                    });
                }
                db.SaveChanges();
                ShowSuccessMessage(true, "Data Save Successfully.");
                ViewState["GridData"] = null;
                tblData.DataSource = null;
                tblData.DataBind();
            }
        }
    }
}