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
using System.Web.Configuration;
public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            Currency.Items.Add(new ListItem("Euros", "0.85"));
            Currency.Items.Add(new ListItem("Japanese Yen", "110.33"));
            Currency.Items.Add(new ListItem("Canadian Dollars", "1.2"));
        }
        Graph.Visible = false;

        Label1.Text = WebConfigurationManager.AppSettings[0];
        }
    protected void ShowGraph_ServerClick(Object sender, EventArgs e)
    {
        Graph.Src = "Pic" + Currency.SelectedIndex.ToString() + ".png";
        Graph.Visible = true;
    }

    protected void but_click(object sender, EventArgs e)
    {
        decimal USAmount = Decimal.Parse(Text1.Value);
        ListItem li = Currency.Items[Currency.SelectedIndex];
        decimal euroAmount = USAmount * Decimal.Parse(li.Value);
        Result.InnerText = USAmount.ToString() + Server.HtmlEncode( " U.S. dollars<> = ");
        Result.InnerText += euroAmount.ToString() + " Euros.";

        
    }

}
