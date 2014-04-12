using System;

/// <summary>
/// GeoAddress is an address object which includes latitude and longitude (and the precison of that geoCoding).
/// </summary>
public class GeoAddress
{
    private string street;
    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    private string city;
    public string City
    {
        get { return city; }
        set { city = value; }
    }

    private string stateCode;
    public string StateCode
    {
        get { return stateCode; }
        set { stateCode = value; }
    }

    private string zipCode;
    public string ZipCode
    {
        get { return zipCode; }
        set { zipCode = value; }
    }

    private string latitude;
    public string Latitude
    {
        get { return latitude; }
        set { latitude = value; }
    }

    private string longitude;
    public string Longitude
    {
        get { return longitude; }
        set { longitude = value; }
    }

    private string precision;
    public string Precision
    {
        get { return precision; }
        set { precision = value; }
    }

    private string warning;
    public string Warning
    {
        get { return warning; }
        set { warning = value; }
    }

    private string errorMessage;
    public string ErrorMessage
    {
        get { return errorMessage; }
        set { errorMessage = value; }
    }

	public GeoAddress(string street, string city, string stateCode, string zipCode, string latitude, string longitude, string precision, string warning, string errorMessage)
	{
        this.street = street;
        this.city = city;
        this.stateCode = stateCode;
        this.zipCode = zipCode;
        this.latitude = latitude;
        this.longitude = longitude;
        this.precision = precision;
        this.warning = warning;
        this.errorMessage = errorMessage;
	}

    
}
