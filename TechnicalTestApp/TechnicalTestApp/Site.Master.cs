using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TechnicalTestApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUtcTime.Text = "UTC: "+DateTime.UtcNow.ToString("hh:mm:ss tt dddd, MMMM dd, yyyy");
            lblLocalTime.Text = "Local: "+DateTime.Now.ToString("hh:mm:ss tt dddd, MMMM dd, yyyy");
        }
    }
}