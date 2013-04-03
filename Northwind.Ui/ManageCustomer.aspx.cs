// ----------------------------------------------------------------------+
// File Name: ManageCustomer.aspx.cs
// Description: This file containing the UI logic of manage customer class.
// Developed By: Arnab Roy Chowdhury.
// Date: 26th February 2012.
// ----------------------------------------------------------------------+

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Northwind.Ui.Code;
using Bll = Northwind.Bll;
using Poco = Northwind.Poco;

namespace Northwind.Ui
{
    /// <summary>
    /// UI logic of manage customer class. It is doing 
    /// create, update and delete operations on customer data.
    /// </summary>
    public partial class ManageCustomer : BasePage
    {
        /// <summary>
        /// Handles the Load event of Page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The EventArgs.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.QueryString["CustomerId"] != null)
                {
                    IList<Northwind.Poco.ICustomer> customers = this.GetCustomers();
                    this.BindDetailsView(customers);
                }
            }
        }

        /// <summary>
        /// Handles the ModeChanging event of dtlvCustomer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The DetailsViewModeEventArgs.</param>
        protected void dtlvCustomer_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            dtlvCustomer.ChangeMode(e.NewMode);
            IList<Northwind.Poco.ICustomer> customers = this.GetCustomers();
            this.BindDetailsView(customers);
        }

        /// <summary>
        /// Handles the ItemInserting event of dtlvCustomer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The DetailsViewInsertEventArgs.</param>
        protected void dtlvCustomer_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                    Poco::ICustomer newCustomer = this.GetCustomerObject();
                    using (Bll::ICustomer blCustomer = new Bll::Customer())
                    {
                        blCustomer.Create(newCustomer);
                    }

                    Response.Redirect("~/Customer.aspx"); // Go and show all data.
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.ToString());
                }
                catch (ObjectDisposedException ex)
                {
                    Response.Write(ex.ToString());
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles the ItemUpdating event of dtlvCustomer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The DetailsViewUpdateEventArgs.</param>
        protected void dtlvCustomer_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                    Poco::ICustomer existingCustomer = this.GetCustomerObject();
                    using (Bll::ICustomer blCustomer = new Bll::Customer())
                    {
                        blCustomer.Update(existingCustomer);
                    }

                    // Back to read only view.
                    dtlvCustomer.ChangeMode(DetailsViewMode.ReadOnly);
                    IList<Northwind.Poco.ICustomer> customers = this.GetCustomers();
                    this.BindDetailsView(customers);
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.ToString());
                }
                catch (ObjectDisposedException ex)
                {
                    Response.Write(ex.ToString());
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            }
        }

        /// <summary>
        /// Handles the ItemDeleting event of dtlvCustomer.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The DetailsViewDeleteEventArgs.</param>
        protected void dtlvCustomer_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            try
            {
                using (Bll::ICustomer blCustomer = new Bll::Customer())
                {
                    if (Request.QueryString["CustomerId"] != null)
                    {
                        blCustomer.Delete(Request.QueryString["CustomerId"]);
                    }

                    Response.Redirect("~/Customer.aspx"); // Go and show all data.
                }
            }
            catch (SqlException ex)
            {
                Response.Write(ex.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                Response.Write(ex.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        #region Helpers
        private IList<Northwind.Poco.ICustomer> GetCustomers()
        {
            IList<Northwind.Poco.ICustomer> customers;

            using (Northwind.Bll.ICustomer customer = new Northwind.Bll.Customer())
            {
                customers = customer.GetData(Request.QueryString["CustomerId"]);
            }

            return customers;
        }

        private void BindDetailsView(IList<Northwind.Poco.ICustomer> customers)
        {
            if (customers != null)
            {
                this.dtlvCustomer.DataSource = customers;
                this.dtlvCustomer.DataBind();
            }
        }

        private Poco::ICustomer GetCustomerObject()
        {
            // Create customer object with data from details view.
            Poco::ICustomer newCustomer = new Poco::Customer()
            {
                CustomerId = ((TextBox)dtlvCustomer.Rows[0].Cells[1].FindControl("TextBox1")) != null
                    ? ((TextBox)dtlvCustomer.Rows[0].Cells[1].FindControl("TextBox1")).Text : string.Empty,
                CompanyName = ((TextBox)dtlvCustomer.Rows[1].Cells[1].FindControl("TextBox2")) != null
                    ? ((TextBox)dtlvCustomer.Rows[1].Cells[1].FindControl("TextBox2")).Text : string.Empty,
                ContactName = ((TextBox)dtlvCustomer.Rows[2].Cells[1].FindControl("TextBox3")) != null
                    ? ((TextBox)dtlvCustomer.Rows[2].Cells[1].FindControl("TextBox3")).Text : string.Empty,
                ContactTitle = ((TextBox)dtlvCustomer.Rows[3].Cells[1].FindControl("TextBox4")) != null
                    ? ((TextBox)dtlvCustomer.Rows[3].Cells[1].FindControl("TextBox4")).Text : string.Empty,
                Country = ((TextBox)dtlvCustomer.Rows[10].Cells[1].FindControl("TextBox6")) != null
                    ? ((TextBox)dtlvCustomer.Rows[10].Cells[1].FindControl("TextBox6")).Text : string.Empty,
                Region = ((TextBox)dtlvCustomer.Rows[4].Cells[1].FindControl("TextBox7")) != null
                    ? ((TextBox)dtlvCustomer.Rows[4].Cells[1].FindControl("TextBox7")).Text : string.Empty,
                City = ((TextBox)dtlvCustomer.Rows[5].Cells[1].FindControl("TextBox8")) != null
                    ? ((TextBox)dtlvCustomer.Rows[5].Cells[1].FindControl("TextBox8")).Text : string.Empty,
                PostalCode = ((TextBox)dtlvCustomer.Rows[6].Cells[1].FindControl("TextBox9")) != null
                    ? ((TextBox)dtlvCustomer.Rows[6].Cells[1].FindControl("TextBox9")).Text : string.Empty,
                Phone = ((TextBox)dtlvCustomer.Rows[7].Cells[1].FindControl("TextBox10")) != null
                    ? ((TextBox)dtlvCustomer.Rows[7].Cells[1].FindControl("TextBox10")).Text : string.Empty,
                Fax = ((TextBox)dtlvCustomer.Rows[8].Cells[1].FindControl("TextBox11")) != null
                    ? ((TextBox)dtlvCustomer.Rows[8].Cells[1].FindControl("TextBox11")).Text : string.Empty,
                Address = ((TextBox)dtlvCustomer.Rows[9].Cells[1].FindControl("TextBox12")) != null
                    ? ((TextBox)dtlvCustomer.Rows[9].Cells[1].FindControl("TextBox12")).Text : string.Empty
            };

            return newCustomer;
        }
        #endregion
    }
}
