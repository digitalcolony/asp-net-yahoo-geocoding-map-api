<%@ page language="C#" MasterPageFile="~/Lab/Lab.master" Title="GeoCoding C# Yahoo Demo | DigitalColony.com" autoeventwireup="true"  CodeFile="GeoCode.aspx.cs" Inherits="GeoCode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div>
         <h3>GeoCoding Address using Yahoo! Map API  </h3> 
         <p>This lab uses the GeoMapping API from Yahoo!  Enter a full or partial address to get an approximate latitude and longitude.  </p>
         <p><strong>UPDATE: Yahoo! no longer supports this API call.</strong></p>
        <table>
            <tr><td><asp:Label AssociatedControlID="txtStreet" runat="server" ID="lblStreet">Street</asp:Label>:</td>
                <td><asp:TextBox ID="txtStreet" runat="server"></asp:TextBox></td></tr>
               <tr><td><asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity">City</asp:Label>:</td>
               <td>
                   <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
               </tr> 
               <tr>
                <td><asp:Label ID="lblState" runat="server" AssociatedControlID="ddlState">State</asp:Label>:</td>
               <td>
                    <asp:DropDownList ID="ddlState" runat="server"></asp:DropDownList>   
                </td> 
               </tr>
               <tr>
               <td><asp:Label ID="lblZipCode" runat="server" AssociatedControlID="txtZipCode">Zip Code</asp:Label>:</td>
               <td>
                   <asp:TextBox ID="txtZipCode" runat="server" MaxLength="10"></asp:TextBox></td>
               </tr>              
               <tr>
               <td></td><td>
                   <asp:Button ID="btnSubmit" runat="server" Text="GeoCode" Enabled="false" />
                   </td>
               </tr>               
        </table>
         
         <div id="divResult" runat="server" style="height:200px;">
        
        </div>

    </div>

</asp:Content>
