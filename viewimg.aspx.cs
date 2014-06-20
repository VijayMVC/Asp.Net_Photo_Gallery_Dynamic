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
using System.IO;

public partial class viewimg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //session begin
        //HyperLink1.NavigateUrl = (string)Session["abc"];
       // HyperLink2.NavigateUrl = (string)Session["abc"];
        //session end

        //retrieve cookie value
        HttpCookie cookie = Request.Cookies["ziacookie"];
        string backurl="gallery.aspx";
        if (cookie != null)
        {
            backurl = cookie["backurl"];
        }
        HyperLink1.NavigateUrl = backurl;
        HyperLink2.NavigateUrl = backurl;
      //cookie end

        string url = Request.QueryString["img"];
        string fullpath=Server.MapPath("upload")+"\\"+url;

        try
        {

            FileInfo fi = new FileInfo(fullpath);
            int size = (int)fi.Length / 1024;
            Label3.Text = "Full name: " + fi.Name + "<br/>" + "Extension: " + fi.Extension + "<br/>" + "Size: " + size + "KB<br/>" + "Read only: " +
                fi.IsReadOnly;
        }
        catch(Exception ex)
        { Response.Write("File not found" +ex); }
    }
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }

   
}
