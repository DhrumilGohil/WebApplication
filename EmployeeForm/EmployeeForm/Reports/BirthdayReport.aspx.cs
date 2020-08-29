using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeForm.Reports
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Models.Employee> Emplist = new List<Models.Employee>();
                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
                var month = Request.QueryString["Searchmonth"];
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand com = new SqlCommand("GetBODEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@month", month);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    Emplist.Add(new Models.Employee()
                    {
                        EmployeeID = Convert.ToInt32(read["EmployeeID"]),
                        FirstName = Convert.ToString(read["FirstName"]),
                        Gender = Convert.ToString(read["Gender"]),
                        Email = Convert.ToString(read["Email"]),
                        LastName = Convert.ToString(read["LastName"]),
                    });
                }
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/EmployeeReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("EmployeeDataset", Emplist);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.DataBind();

            }
        }
    }
}