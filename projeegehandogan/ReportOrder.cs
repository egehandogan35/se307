using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopManagementSystem
{
    public partial class ReportOrder : Form
    {
        /*
         * 
         * 
         *This class generates the report of orders. 
         * 
         * 
         */ 
        SqlConnection con;

        public ReportOrder()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                Connect connectObj = new Connect();
                con = connectObj.connect();
                var select = "SELECT * FROM ORDER_VIEW WHERE DATE BETWEEN @start AND @end ;";

                var dataAdapter = new SqlDataAdapter(select, con);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@start", FromDate.Text);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@end", Todate.Text);
              
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                dataGridView1.ReadOnly = true;
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(con != null)
                {
                    con.Close();
                }
            }

            
        }
        private void ReportOrder_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
