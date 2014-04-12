using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Xml;
using System.Xml.XPath;

/// <summary>
/// GeoAddressAPI is the class that interfaces w/ Yahoo! Mapping GeoCoding web serice.
/// </summary>
public class GeoAddressAPI
{
    private string apiURL;

	public GeoAddressAPI()
	{
		apiURL = WebConfigurationManager.AppSettings["apiURL"];
	}
    public GeoAddress GeoEncodeAddress(string street, string city, string stateCode, string zipCode)
    {
        string latitude = "";
        string longitude = "";
        string precison = "";
        string warning = "";
        string errorMessage = "";
        
        // Build URL request to be sent to Yahoo!
        string url = "";
        if (street.Length > 0)
        {
            url += "&street=" + street;
        }
        if (city.Length > 0)
        {
            url += "&city=" + city;
        }
        if (stateCode.Length == 2)
        {
            url += "&state=" + stateCode;
        }
        if (zipCode.Length >= 5)
        {
            url += "&zip=" + zipCode;
        }
        url = apiURL + url;        
        url = url.Replace(" ", "+");  // Yahoo example shows + sign instead of spaces.

        // Read Returned XML file from YAHOO!
        try
        {
            XmlReader reader = new XmlTextReader(url);
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(reader);
            /*
               There is no default namespace being used, meaning that all non-prefixed (or embedded) elements DO NOT belong to ANY namespace. 
               This allows you to execute XPath statements without prefixes. 
               XPath queries does not support 'default' namespaces. 
               You have to adjust your XPath query to include that namespace. 
           */
            XmlNamespaceManager xMngr = new XmlNamespaceManager(xDoc.NameTable);
            xMngr.AddNamespace("yahoo", "urn:yahoo:maps");                        

            try  /*  STREET */
            {
                XmlNode xStreet;
                xStreet = xDoc.SelectSingleNode("//yahoo:Address", xMngr);
                street = xStreet.InnerText;
            }
            catch
            {
                street = "";
            }

            try /* CITY */
            {
                XmlNode xCity;
                xCity = xDoc.SelectSingleNode("//yahoo:City", xMngr);
                city = xCity.InnerText;
            }
            catch
            {
                city = "";
            }

            try /* STATE */
            {
                XmlNode xStateCode;
                xStateCode = xDoc.SelectSingleNode("//yahoo:State", xMngr);
                stateCode = xStateCode.InnerText;
            }
            catch
            {
                stateCode = "";
            }

            try /* ZIPCODE */
            {
                XmlNode xZipCode;
                xZipCode = xDoc.SelectSingleNode("//yahoo:Zip", xMngr);
                zipCode = xZipCode.InnerText;
            }
            catch
            {
                zipCode = "";
            }

            try /* LATITUDE , LONGITUDE, PRECISION */
            {
                XmlNode xLatitude;
                xLatitude = xDoc.SelectSingleNode("//yahoo:Latitude", xMngr);
                latitude = xLatitude.InnerText;
                XmlNode xLongitude;
                xLongitude = xDoc.SelectSingleNode("//yahoo:Longitude", xMngr);
                longitude = xLongitude.InnerText;
                XmlNode xPrecision;
                xPrecision = xDoc.SelectSingleNode("//yahoo:Result/@precision", xMngr);
                precison = xPrecision.InnerText;
            }
            catch
            {
                latitude = "";
                longitude = "";
                precison = "";
            }

            try  // warning is only returned if address unclear
            {
                XmlNode xWarning;
                xWarning = xDoc.SelectSingleNode("//yahoo:Result/@warning", xMngr);
                warning = xWarning.InnerText;
                // Yahoo! embeds the depreciated <b> tag in this result (yuck!), we need to remove it.
                warning = Regex.Replace(warning, @"<(.|\n)*?>", string.Empty);
            }
            catch
            {
                warning = "";
            }

            GeoAddress address = new GeoAddress(street, city, stateCode, zipCode, latitude, longitude, precison, warning, errorMessage);
            return address;
        }
        catch (WebException webException) 
        {
            errorMessage = webException.Message;
            GeoAddress address = new GeoAddress(street, city, stateCode, zipCode, latitude, longitude, precison, warning, errorMessage);
            return address;
        }       
        
    }
}
