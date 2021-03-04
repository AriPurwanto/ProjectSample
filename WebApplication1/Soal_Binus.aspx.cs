using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication1
{
    public partial class Soal_Binus : System.Web.UI.Page
    {
        private string strConString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        private string message;

        public void dataLoad_Grid()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spLoadGridView";
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = textNoInvoice.Text.Trim();
            cmd.Connection = con;

            try
            {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        GridResult.DataSource = dt;
                        GridResult.DataBind();
                    }

                    con.Close();
                
            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        public void dataLoad_Sales()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("spLoadSales", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    ddSalesName.DataSource = dt;
                    ddSalesName.DataValueField = "SalesName";
                    ddSalesName.DataBind();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        public void dataLoad_Courier()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strConString))
                {
                    SqlCommand cmd = new SqlCommand("spLoadCourier", con);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();

                    ddCourier.DataSource = dt;
                    ddCourier.DataValueField = "CourierName";
                    ddCourier.DataBind();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        public void dataLoad_PaymentType()
        {
            ddPaymentType.Items.Add(new ListItem("Cash", "Cash"));
            ddPaymentType.Items.Add(new ListItem("COD", "COD"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          if (!IsPostBack)
           {
              //dataLoad_Grid();
              dataLoad_Sales();
              dataLoad_Courier();
              dataLoad_PaymentType();
           }
        }

        public void SubTotal()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spSubTotal";
            cmd.Parameters.Add("@NoInvoice", SqlDbType.VarChar).Value = textNoInvoice.Text.Trim();
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lblSubTotal.Text = dt.Rows[0].ItemArray[1].ToString();
                }

                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        public void CourierFee()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spCourierFee";
            cmd.Parameters.Add("@NoInvoice", SqlDbType.VarChar).Value = textNoInvoice.Text.Trim();
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lblCourierFee.Text = dt.Rows[0].ItemArray[1].ToString();
                }

                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        public void Total()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spSubTotal";
            cmd.Parameters.Add("@NoInvoice", SqlDbType.VarChar).Value = textNoInvoice.Text.Trim();
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lblTotal.Text = dt.Rows[0].ItemArray[1].ToString();
                }

                con.Close();

            }
            catch (Exception ex)
            {
                message = ex.Message;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Oops!! following error occured : " + message.ToString() + "');", true);
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "spFindInvoice";
            cmd.Parameters.Add("@InvoiceNo", SqlDbType.VarChar).Value = textNoInvoice.Text.Trim();
            cmd.Connection = con;

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    textInvoiceDate.Text = dt.Rows[0].ItemArray[1].ToString();
                    textTo.Text = dt.Rows[0].ItemArray[2].ToString();
                    textShipTo.Text = dt.Rows[0].ItemArray[3].ToString();
                    ddPaymentType.Text = dt.Rows[0].ItemArray[4].ToString();
                    ddSalesName.Text = dt.Rows[0].ItemArray[5].ToString();
                    ddCourier.Text = dt.Rows[0].ItemArray[6].ToString();
                }

                dataLoad_Grid();
                CourierFee();
                SubTotal();
                Total();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}