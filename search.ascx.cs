using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length < 3)
        {
            Label1.Visible = true;
            Label1.Text = "Please enter atleast 3 letters";
        }
        else
        {

            Response.Redirect("gallery.aspx?key=" + TextBox1.Text);

        }

        
    }
}
