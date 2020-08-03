using EmployeeForm.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Web;
using System.Web.WebSockets;

namespace EmployeeForm.Repository
{
    public class EmpRepository
    {
        public List<Employee> GetAllEmployee([Optional]int EmployeeID)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            List<Employee> EmpList = new List<Employee>();
            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(

                    new Employee()
                    {
                        EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        MiddleName = Convert.ToString(dr["MiddleName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Gender = (dr["Gender"].ToString()),
                        Email = Convert.ToString(dr["Email"]),
                        PresentAddress = Convert.ToString(dr["PresentAddress"]),
                        PresentDistrictID = Convert.ToInt32(dr["PresentDistrictID"]),
                        PresentTalukaID = Convert.ToInt32(dr["PresentTalukaID"]),
                        PresentPINCODE = Convert.ToInt32(dr["PresentPINCODE"]),
                        NativeAddress = Convert.ToString(dr["NativeAddress"]),
                        NativeDistrictID = Convert.ToInt32(dr["NativeDistrictID"]),
                        NativeTalukaID = Convert.ToInt32(dr["NativeTalukaID"]),
                        NativePINCODE = Convert.ToInt32(dr["NativePINCODE"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                        AlternatePhoneNumber = Convert.ToString(dr["AlternatePhoneNumber"]),
                        EmergencyContactNumber = Convert.ToString(dr["EmergencyContactNumber"]),
                        EmergencyContactName = Convert.ToString(dr["EmergencyContactName"]),
                        DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                        Dateofjoin = Convert.ToDateTime(dr["DateOfJoin"]),
                        DateofRetirement = Convert.ToDateTime(dr["DateofRetirement"]),
                        DistrictJoiningDate = Convert.ToDateTime(dr["DistrictJoiningDate"]),
                        EmployeeEntryinDistrict = Convert.ToString(dr["EmployeeEntryinDistrict"]),
                        EmployeeType = Convert.ToString(dr["EmployeeType"]),
                        AgencyID = Convert.ToInt32(dr["AgencyID"]),
                        CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                        CreatedDate = Convert.ToDateTime(dr["CreatedDate"]),
                        UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]),
                        UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]),
                        isActive = Convert.ToBoolean(dr["isActive"]),
                    }

                    );
            }

            return EmpList;


        }

        public bool AddEmployee(Employee obj)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("AddNewEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            com.Parameters.AddWithValue("@Gender", Convert.ToString(obj.Gender));
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@PresentAddress", obj.PresentAddress);
            com.Parameters.AddWithValue("@PresentDistrictID", obj.PresentDistrictID);
            com.Parameters.AddWithValue("@PresentTalukaID", obj.PresentTalukaID);
            com.Parameters.AddWithValue("@PresentPinCode", obj.PresentPINCODE);
            com.Parameters.AddWithValue("@NativeAddress", obj.NativeAddress);
            com.Parameters.AddWithValue("@NativeDistrictID", obj.NativeDistrictID);
            com.Parameters.AddWithValue("@NativeTalukaID", obj.NativeTalukaID);
            com.Parameters.AddWithValue("@NativePinCode", obj.NativePINCODE);
            com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            com.Parameters.AddWithValue("@AlternatePhoneNumber", obj.AlternatePhoneNumber);
            com.Parameters.AddWithValue("@EmergencyContactNumber", obj.EmergencyContactNumber);
            com.Parameters.AddWithValue("@EmergencyContactName", obj.EmergencyContactName);
            com.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
            com.Parameters.AddWithValue("@Dateofjoin", obj.Dateofjoin);
            com.Parameters.AddWithValue("@DateofRetirement", obj.DateofRetirement);
            com.Parameters.AddWithValue("@DistrictJoiningDate", obj.DistrictJoiningDate);
            com.Parameters.AddWithValue("@EmployeeEntryinDistrict", Convert.ToString(obj.EmployeeEntryinDistrict));
            com.Parameters.AddWithValue("@EmployeeType", obj.EmployeeType);
            com.Parameters.AddWithValue("@AgencyID", obj.AgencyID);
            com.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            com.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            com.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            com.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            com.Parameters.AddWithValue("@isActive", 1);
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateEmp(Employee obj)
        {
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("UpdateEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@MiddleName", obj.MiddleName);
            com.Parameters.AddWithValue("@Gender", Convert.ToString(obj.Gender));
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@PresentAddress", obj.PresentAddress);
            com.Parameters.AddWithValue("@PresentDistrictID", obj.PresentDistrictID);
            com.Parameters.AddWithValue("@PresentTalukaID", obj.PresentTalukaID);
            com.Parameters.AddWithValue("@PresentPinCode", obj.PresentPINCODE);
            com.Parameters.AddWithValue("@NativeAddress", obj.NativeAddress);
            com.Parameters.AddWithValue("@NativeDistrictID", obj.NativeDistrictID);
            com.Parameters.AddWithValue("@NativeTalukaID", obj.NativeTalukaID);
            com.Parameters.AddWithValue("@NativePinCode", obj.NativePINCODE);
            com.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            com.Parameters.AddWithValue("@AlternatePhoneNumber", obj.AlternatePhoneNumber);
            com.Parameters.AddWithValue("@EmergencyContactNumber", obj.EmergencyContactNumber);
            com.Parameters.AddWithValue("@EmergencyContactName", obj.EmergencyContactName);
            com.Parameters.AddWithValue("@DateOfBirth", obj.DateOfBirth);
            com.Parameters.AddWithValue("@Dateofjoin", obj.Dateofjoin);
            com.Parameters.AddWithValue("@DateofRetirement", obj.DateofRetirement);
            com.Parameters.AddWithValue("@DistrictJoiningDate", obj.DistrictJoiningDate);
            com.Parameters.AddWithValue("@EmployeeEntryinDistrict", Convert.ToString(obj.EmployeeEntryinDistrict));
            com.Parameters.AddWithValue("@EmployeeType", obj.EmployeeType);
            com.Parameters.AddWithValue("@AgencyID", obj.AgencyID);
            com.Parameters.AddWithValue("@CreatedBy", obj.CreatedBy);
            com.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            com.Parameters.AddWithValue("@UpdatedBy", obj.UpdatedBy);
            com.Parameters.AddWithValue("@UpdatedDate", DateTime.Now);
            com.Parameters.AddWithValue("@isActive", 1);
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<District> GetAllDistrict()
        {
            List<District> Districts = new List<District>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllDistricts", con);
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Districts.Add(new District
                { 
                    DistrictID = Convert.ToInt32(read["DistrictID"]),
                    DistrictName = Convert.ToString(read["DistrictName"])
                }); 
            }

            return Districts;
        }

        public List<Taluka> GetAllTaluka(int DistrictID)
        {
            List<Taluka> Talukas = new List<Taluka>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllTaluka", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DistrictID", DistrictID);
            DataTable dt = new DataTable();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                
                Talukas.Add(new Taluka
                {
                        TalukaID = Convert.ToInt32(read["TalukaID"]),
                        TalukaName =Convert.ToString(read["TalukaName"])
                });
            }
            return Talukas;

        }

        public List<Agency> GetAllAgency()
        {
            List<Agency> Agencies = new List<Agency>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllAgencies", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Agencies.Add(new Agency()
                { 
                   AgencyName = Convert.ToString(read["AgencyName"]),
                   AgencyID = Convert.ToInt32(read["AgencyID"])
                
                });
            }
            return Agencies;

        }
        public List<Taluka> AllTalukasDetail()
        {
            List<Taluka> Talukaslist = new List<Taluka>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;


            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("AllTalukaDetail"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Talukaslist.Add(new Taluka
                            {
                                DistrictID = Convert.ToInt32(sdr["DistrictID"]),
                                TalukaID = Convert.ToInt32(sdr["TalukaID"]),
                                TalukaName = Convert.ToString(sdr["TalukaName"]),
                                CreatedBy = Convert.ToInt32(sdr["CreatedBy"]),
                                CreatedDate = Convert.ToDateTime(sdr["CreatedDate"])
                            });
                        }
                        con.Close();
                        return Talukaslist;
                    }
                }
            }
        }

        public List<District> AllDistricsDetail()
        {
            List<District> Districtslist = new List<District>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;


            using (SqlConnection con = new SqlConnection(constr))
            {

                using (SqlCommand cmd = new SqlCommand("DetailsDistrict"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Districtslist.Add(new District()
                            {
                                DistrictID = Convert.ToInt32(sdr["DistrictID"]),
                                DistrictName = Convert.ToString(sdr["DistrictName"]),
                                CreatedBy = Convert.ToInt32(sdr["CreatedBy"]),
                                CreatedDate = Convert.ToDateTime(sdr["CreatedDate"])
                            });
                        }
                        con.Close();
                        return Districtslist;
                    }
                }
            }

        }

        public bool addAgency(Agency Age)
        {
            string constr = ConfigurationManager.ConnectionStrings["Empconnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("Addagency",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@AgencyName", Age.AgencyName);
            com.Parameters.AddWithValue("@createdBy", Age.CreatedBy);
            com.Parameters.AddWithValue("@createdDate", DateTime.Now);
            int affectedRow = com.ExecuteNonQuery();
            con.Close();
            if (affectedRow > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<Agency> ListAgency()
        {
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            List<Agency> Listofagency = new List<Agency>();
            con.Open();
            SqlCommand com = new SqlCommand("GetAllDetailAgency", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = com.ExecuteReader();
            while (read.Read()) {
                Listofagency.Add(new Agency()
                {
                    AgencyID = Convert.ToInt32(read["AgencyID"]),
                    AgencyName = Convert.ToString(read["AgencyName"]),
                    CreatedBy = Convert.ToInt32(read["CreatedBy"]),
                    CreatedDate = Convert.ToDateTime(read["CreatedDate"])
                }); 
            }
            return Listofagency;
        }

        public List<Cadres> ListCadres()
        {
            List<Cadres> GetAllCadres = new List<Cadres>();
            string Constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(Constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllCadres", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                GetAllCadres.Add(new Cadres()
                {
                    CadresID = Convert.ToInt32(read["CadresID"]),
                    CadresName = Convert.ToString(read["CadresName"]),
                    CreatedBy = Convert.ToInt32(read["CreatedBy"]),
                    CreatedDate = Convert.ToDateTime(read["CreatedDate"])
                });
            }
            return GetAllCadres;
        }
        public List<EmpDesignation> ListDesignation()
        {
            List<EmpDesignation> ListofDesignation = new List<EmpDesignation>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllDesignation", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ListofDesignation.Add(new EmpDesignation()
                {
                    DesignationID = Convert.ToInt32(read["DesignationID"]),
                    DesignationName = Convert.ToString(read["DesignationName"]),
                    CreatedBy = Convert.ToInt32(read["CreatedBy"]),
                    CreatedDate = Convert.ToDateTime(read["CreatedDate"])
                });
            }
            return ListofDesignation;
        }
        public List<Exam> ListExam()
        {
            List<Exam> ListofExam = new List<Exam>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllExam", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                ListofExam.Add(new Exam()
                {
                    ExamID = Convert.ToInt32(read["ExamID"]),
                    ExamName = Convert.ToString(read["ExamName"]),
                    CreatedBy = Convert.ToInt32(read["CreatedBy"]),
                    CreatedDate = Convert.ToDateTime(read["CreatedDate"]),
                    UpdatedBy = Convert.ToInt32(read["UpdatedBy"]),
                    UpdatedDate = Convert.ToDateTime(read["UpdatedDate"])
                });
            }
            return ListofExam;
        }
    }
   
}

    /* public bool deleteEmployee(int EmployeeId)
         {
             string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
             SqlConnection con = new SqlConnection(constr);
             con.Open();
             SqlCommand com = new SqlCommand("DeleteEmployee", con);
             com.CommandType = CommandType.StoredProcedure;
             com.Parameters.AddWithValue("@EmployeeID", EmployeeId);

             int i = com.ExecuteNonQuery();
             con.Close();
             if (i >= 1)
             {
                 return true;
             }
             else
             {
                 return false;
             }


         }

     }*/

