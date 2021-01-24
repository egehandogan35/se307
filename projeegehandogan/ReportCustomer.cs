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
    public partial class ReportCustomer : Form
    {
        /*
         * 
         * 
         * This class generates the report of customer
         * 
         * 
         */ 
        SqlConnection con;
        public ReportCustomer()
        {
            InitializeComponent();
        }

       
        private void ReportCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                Connect connectObj = new Connect();
                con = connectObj.connect();
                var select = "SELECT * FROM CUSTOMER";
                
                var dataAdapter = new SqlDataAdapter(select, con);

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

        private void ReportCustomer_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
