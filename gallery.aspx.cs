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

public partial class gallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["abc"] = Request.Url.PathAndQuery;
        //cookie
        HttpCookie cookie = new HttpCookie("ziacookie");
        cookie["backurl"]=Request.Url.PathAndQuery;
        Response.Cookies.Add(cookie);
        
        
        

    }


   
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        
    }
}
