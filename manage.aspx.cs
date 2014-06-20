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

public partial class manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Write( GridView1.SelectedDataKey.Value.ToString());
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {

            string txt = GridView1.Rows[e.RowIndex].Cells[2].Text;
            File.Delete(Server.MapPath("upload") + "\\thumbs\\" + txt);
            File.Delete(Server.MapPath("upload") + "\\" + txt);
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //get keywords
            string key = (string)DataBinder.Eval(e.Row.DataItem, "Keywords");
            if (key != "")
            {
                e.Row.BackColor = System.Drawing.Color.Cornsilk;
                e.Row.Font.Bold = true;
            }

            // Check Null Image code
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image CurrentImage = (Image)e.Row.FindControl("Image1");
                if (!File.Exists(Server.MapPath(CurrentImage.ImageUrl)))
                {
                    // if image not exists, use default image
                    CurrentImage.ImageUrl = "null.jpg";
                }
            }

            
                
        }
    }
    protected void GridView1_Sorted(object sender, EventArgs e)
    {
        GridView1.SelectedIndex = -1;
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "StatusClick")
            Response.Write( e.CommandArgument.ToString());

    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.className='hightlighrow';this.style.cursor='hand'");
            e.Row.Attributes.Add("onmouseout", "this.className='normalrow'");
            e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
        //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
        //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            
        //}


    }
}
