﻿using EmployeeForm.Models;
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
        public List<Employee> GetAllEmployee([Optional] int EmployeeID)
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
        public List<string> GetAllDistrict()
        {
            List<string> Districts = new List<string>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllDistricts", con);
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Districts.Add(Convert.ToString(read["DistrictName"]));
            }

            return Districts; 
        }

        public List<string> GetAllTaluka(int DistrictID) {
            List<string> Talukas = new List<string>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllTaluka", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DistrictID", DistrictID);
            DataTable dt = new DataTable();
            SqlDataReader read = com.ExecuteReader();
             while(read.Read())
            {
                Console.WriteLine(read["TalukaName"]);
                Talukas.Add(Convert.ToString(read["TalukaName"]));
            }
            return Talukas;

        } 

        public List<string> GetAllAgency()
        {
            List<string> Agencies = new List<string>();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("GetAllAgencies", con);
            com.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataReader read = com.ExecuteReader();
            while(read.Read())
            {               
                Agencies.Add(Convert.ToString(read["AgencyName"]));
            }
            return Agencies;

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

}