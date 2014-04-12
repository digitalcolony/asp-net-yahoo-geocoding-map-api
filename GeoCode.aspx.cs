using System;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class GeoCode : System.Web.UI.Page
{
    private GeoAddressAPI geoAPI = new GeoAddressAPI();
      
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            string street = txtStreet.Text;
            //remove # sign from address - as it does wacky things
            street = street.Replace("#", " ");
            string city = txtCity.Text;
            string stateCode = ddlState.SelectedValue.ToString();
            string zipCode = txtZipCode.Text;
           
            GeoAddress address = geoAPI.GeoEncodeAddress(street, city, stateCode, zipCode);

            StringBuilder sbResult = new StringBuilder();
            sbResult.Append("<br/>Street:" + address.Street);
            sbResult.Append("<br/>City: " + address.City);
            sbResult.Append("<br/>State: " + address.StateCode);
            sbResult.Append("<br/>ZipCode: " + address.ZipCode);
            sbResult.Append("<br/>Latitude: " + address.Latitude);
            sbResult.Append("<br/>Longitude: " + address.Longitude);
            sbResult.Append("<br/>Precision: " + address.Precision);
            sbResult.Append("<br/>Warning: " + address.Warning);
            sbResult.Append("<br/>Error Message: " + address.ErrorMessage);
            
            divResult.InnerHtml= sbResult.ToString();                      
        }
        else  // Load state drop down
        {          
            string stateCodes = "AL AK AZ AR CA CO CT DE FL GA HI ID IL IN IA KS KY LA ME MD MA MI MN MS MO MT NE NV NH NJ NM NY NC ND OH OK OR PA RI SC SD TN TX UT VT VA WA WA-DC WV WI WY";
            ArrayList arrStates = new ArrayList(stateCodes.Split(' '));
            ddlState.Items.Add("");
            foreach (string stateCode in arrStates)
            {
                ddlState.Items.Add(stateCode);
            }
        }
    }

}
