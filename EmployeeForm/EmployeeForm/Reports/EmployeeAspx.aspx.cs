using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeForm.Reports
{
    public partial class EmployeeAspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Models.Employee> Emplist = new List<Models.Employee>();
                string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
                var date = Request.QueryString["Searchdate"];
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand com = new SqlCommand("GetRetireEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Date", date);
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
                        EmployeeType = Convert.ToString(read["DistrictName"]),
                     });
                }
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/EmployeeReport.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rdc = new ReportDataSource("EmployeeDataset",Emplist);
                ReportViewer1.LocalReport.DataSources.Add(rdc);
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.DataBind();

            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}