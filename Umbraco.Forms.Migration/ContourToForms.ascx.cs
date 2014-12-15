using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Umbraco.Forms.Migration
{
    public partial class ContourToForms : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var s = new MigrationService();
                s.Migrate(TextBox1.Text);
            }
            catch(Exception ex)
            {
                Literal1.Text = ex.Message + "<br/>" + ex.StackTrace;
            }
            Literal1.Text = "Migration completed";
        }
    }
}