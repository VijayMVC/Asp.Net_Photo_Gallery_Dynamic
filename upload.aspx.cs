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
using System.Data.SqlClient;
//using System.IO;

public partial class upload : System.Web.UI.Page
{
    string path,name;
    int count;
    protected void Page_Load(object sender, EventArgs e)
    {

        

        Label1.Visible = false;
        //check postback
        if (!Page.IsPostBack)
        {
            // Hit Counter
            //lock
            Application.Lock();
            int count = 0;
            if (Application["hitcounter"] != null)
            {
                count = (int)Application["hitcounter"];
            }
            count++;
            Application["hitcounter"] = count;
            Application.UnLock();
            counter.Text = count.ToString();
            //end hit counter
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        checkname();
        int len = FileUpload1.FileName.Length;
        if (len > 50)
        {
            Label1.Visible = true;
            Label1.Text = "File name is too long. Please rename the file and upload";
        }
        else
        {

            if (FileUpload1.HasFile)
            {
                if (count == 0)
                {
                    path = Server.MapPath("upload");
                    name = FileUpload1.FileName;
                    path += "\\" + name;
                    FileUpload1.SaveAs(path);
                    Label1.Visible = true;
                    Label1.Text = "<b>" + FileUpload1.FileName + "</b> Uploaded Successfully to <br/>" + path;
                    sqlins();
                    thumbs();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "File with the same <b>name</b> and <b>size</b> already exists";
                }
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Please select a file to upload";

            }
        }
    }

    public void checkname()
    {
        
        SqlConnection conn = new
SqlConnection(ConfigurationManager.ConnectionStrings[
"ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select Url,Size from meta", conn);
        SqlDataReader rdr;
        conn.Open();
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        while (rdr.Read())
        {
            if (FileUpload1.FileName == rdr["Url"].ToString()&& FileUpload1.PostedFile.ContentLength==(int)rdr["Size"])
            {
                count = 1;
                
            }
        }

    }

    public void sqlins()
    {
        SqlConnection scon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand scmd = new SqlCommand("Insert into meta (Name,Url,Date,Keywords,Size) Values(@Name,@Url,@Date,@Keywords,@Size)");
        scmd.Connection = scon;
        scmd.Parameters.Add("@Name", SqlDbType.VarChar, 150);
        scmd.Parameters.Add("@Url", SqlDbType.VarChar, 250);
        scmd.Parameters.Add("@Date", SqlDbType.DateTime);
        scmd.Parameters.Add("@Keywords", SqlDbType.VarChar, 150);
        //scmd.Parameters.Add("@Size", SqlDbType.VarChar, 150);
        scmd.Parameters.AddWithValue("@Size", FileUpload1.PostedFile.ContentLength);

        

        String noext = System.IO.Path.GetFileNameWithoutExtension(name);
        scmd.Parameters["@Name"].Value = noext;
        scmd.Parameters["@Url"].Value = name;
        scmd.Parameters["@Date"].Value = DateTime.Now;
        scmd.Parameters["@Keywords"].Value =TextBox1.Text ;
        //scmd.Parameters["@Size"].Value = FileUpload1.PostedFile.ContentLength;

        scon.Open();
        scmd.ExecuteNonQuery();
        scon.Close();

    }
    public void thumbs()
    {
        System.Drawing.Image img = null;
        img = System.Drawing.Image.FromFile(path);
        System.Drawing.Image imgthumb = null;
        imgthumb = img.GetThumbnailImage(100, 100, null, new IntPtr());
        string thumbpath = Server.MapPath("upload") + "\\thumbs\\" + name;
        imgthumb.Save(thumbpath);
    }

    
}
