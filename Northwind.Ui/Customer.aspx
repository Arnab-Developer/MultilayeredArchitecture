<%@ Page Title="Customer" Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs"
    Inherits="Northwind.Ui.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grvCustomers" runat="server">
        <Columns>
            <asp:HyperLinkField DataTextField="CompanyName" DataNavigateUrlFields="CustomerId"
                DataNavigateUrlFormatString="~/ManageCustomer.aspx?CustomerId={0}" 
                HeaderText="Company Name" />
            <asp:BoundField DataField="ContactName" HeaderText="Contact Name" />
            <asp:BoundField DataField="ContactTitle" HeaderText="Contact Title" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Country" HeaderText="Country" />
            <asp:BoundField DataField="Region" HeaderText="Region" />
            <asp:BoundField DataField="City" HeaderText="City" />
            <asp:BoundField DataField="PostalCode" HeaderText="Postal Code" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:BoundField DataField="Fax" HeaderText="Fax" />
        </Columns>
    </asp:GridView>
</asp:Content>
