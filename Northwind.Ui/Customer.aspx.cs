// ------------------------------------------------------------------+
// File Name: Default.aspx.cs
// Description: This file containing the UI logic of customer class.
// Developed By: Arnab Roy Chowdhury.
// Date: 26th February 2012.
// ------------------------------------------------------------------+

using System;
using System.Collections.Generic;
using System.Web.Configuration;
using Northwind.Ui.Code;

namespace Northwind.Ui
{
    /// <summary>
    /// Ui logic of customer.
    /// </summary>
    public partial class Customer : BasePage
    {
        /// <summary>
        /// Handles the Load event of Page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The EventArgs.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Northwind.Poco.ICustomer> customers;

            using (Northwind.Bll.ICustomer customer = new Northwind.Bll.Customer()) // Interface type to decouple the BLL.
            {
                customers = customer.GetData();
            }

            if (customers != null)
            {
                this.grvCustomers.DataSource = customers;
                this.grvCustomers.DataBind();
            }
        }
    }
}
