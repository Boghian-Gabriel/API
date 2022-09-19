using Microsoft.Reporting.WinForms;
using System.Data;
using System.Data.SqlClient;

namespace RDLCDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection(@"Data Source=PC162\SQL2019;Initial Catalog=MovieDB;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Movies", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource source = new ReportDataSource("DataSet1", dataTable);
            reportViewer1.LocalReport.ReportPath = @"C:\\Users\\admin\\Desktop\\WebAPIExample\\API_V2\\RDLCDesign\\RptMovies.rdlc";
            reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();
        }
    }
}