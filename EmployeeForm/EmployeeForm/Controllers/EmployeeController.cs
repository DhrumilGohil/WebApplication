﻿using EmployeeForm.Models;
using EmployeeForm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Microsoft.Ajax.Utilities;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
         public ActionResult ShowAllEmployee()
         {
             EmpRepository EmpRepo = new EmpRepository();
             ModelState.Clear();
             return View(EmpRepo.GetAllEmployee());
         }


        // GET: Employee/Create
        public ActionResult AddEmp()
        {            
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult AddEmp(Employee Emp)
        {
            int now = DateTime.Now.Year;
            int years = Emp.DateOfBirth.Year;
            if ((now - years) < 18)
            {
                ViewBag.Message = "You are not Eligible to apply..";
            }
            else if (Emp.DateOfBirth > Emp.Dateofjoin)
            {
                ViewBag.ErrorMessage = "Conflicts in Birthdate and joining Date";
            }
            else
            {
                EmpRepository Emprepo = new EmpRepository();
                if (Emprepo.AddEmployee(Emp))
                {
                    return RedirectToAction("ShowAllEmployee");
                }
                else
                {
                    return RedirectToAction("Error");
                }

            }
            return View();

        }

        // GET: Employee/Edit/5
        public ActionResult EditEmp(int id)
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Employee> test = new List<Employee>();
            test = Emprepo.GetAllEmployee(id);
            foreach (var item in test)
            {
                ViewBag.Emptype = item.EmployeeType;
                ViewBag.District = item.PresentDistrictID;
                ViewBag.Taluka = item.PresentTalukaID;
                ViewBag.Ndistrict = item.NativeDistrictID;
                ViewBag.Ntaluka = item.NativeTalukaID;
                ViewBag.Agency = item.AgencyID;
            }
            return View(Emprepo.GetAllEmployee(id));
        }                      

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditEmp(Employee Emp)
        {
            int now = DateTime.Now.Year;
            int years = Emp.DateOfBirth.Year;
            if ((now - years) < 18)
            {
                ViewBag.Message = "You are not Eligible to apply..";
            }
            else if (Emp.DateOfBirth > Emp.Dateofjoin)
            {
                ViewBag.ErrorMessage = "Conflicts in Birthdate and joining Date";
            }
            else
            {
                EmpRepository Emprepo = new EmpRepository();
                if (Emprepo.UpdateEmp(Emp))
                {
                    return RedirectToAction("ShowAllEmployee");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }

            return View();
        }
        [HttpGet]
        public JsonResult GetAllDistrict()
        {
            EmpRepository Emprepo = new EmpRepository();
            List<string> Districts = Emprepo.GetAllDistrict().ToList();            
            return Json(Districts, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllTalukas(int Empid)
        {
            EmpRepository Emprepo = new EmpRepository();
            List<string> Talukas = Emprepo.GetAllTaluka(Empid);            
            return Json(Talukas, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllAgencies()
        {
            EmpRepository Emprepo = new EmpRepository();
            List<string> Agencies = Emprepo.GetAllAgency();
            return Json(Agencies,JsonRequestBehavior.AllowGet);
        }

        public ActionResult DetailS(int id)
        {
            EmpRepository Emprepo = new EmpRepository();
            ModelState.Clear();
            return View(Emprepo.GetAllEmployee(id));
        }

        public ActionResult EmpActive(int id)
        {
            EmpRepository Emprepo = new EmpRepository();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("ISACTIVE", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeID", id);
            com.Parameters.AddWithValue("@isActive", 0);
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                return RedirectToAction("ShowAllEmployee");
            }
            else
            { 
                return RedirectToAction("Error");
            }

        }

        public ActionResult search(string Search)
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Employee> test = new List<Employee>();
            test = Emprepo.GetAllEmployee();


            return View(test.Where(x=> x.FirstName.Contains(Search)).ToList());
        }

        public ActionResult MehkamDetail()
        {
            return View();
        }

        public ActionResult Cadres()
        {
            return View();
        }

        public ActionResult Agency()
        {
            return View();
        }          

        public ActionResult EmployeeJobDetails()
        {
            return View();
        }

        public ActionResult Taluka()
        {
            return View();
        }
        public ActionResult District()
        {
            return View();
        }

        public ActionResult Exam()
        {
            return View();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        }

        public ActionResult EmployeeExam()
        {
            return View();
        }

        public ActionResult Office()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Designation()
        {
            return View();
        }
    }
}

        // GET: Employee/Delete/5
      /*  public ActionResult DeleteEmp(int id)
        {
            EmpRepository Emprepo = new EmpRepository();
            Emprepo.deleteEmployee(id);

            return RedirectToAction("ShowAllEmployee");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteEmp()
        {
            return RedirectToAction("ShowAllEmployee");

        }
       
        public ActionResult EmpActive(int id)
        {
            EmpRepository Emprepo = new EmpRepository();
            string constr = ConfigurationManager.ConnectionStrings["EmpConnect"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand com = new SqlCommand("ISACTIVE", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmployeeID", id);
            com.Parameters.AddWithValue("@isActive", 0);
            com.ExecuteNonQuery();

            int i = com.ExecuteNonQuery();
            con.Close();
            if(i > 1)
            {
                return RedirectToAction("ShowAllEmployee");
            }
            else
            {
                return RedirectToAction("Error");
            }
            
        }

        public ActionResult Detail(int id)
        {
            EmpRepository Emprepo = new EmpRepository();
            ModelState.Clear();
            return View(Emprepo.GetAllEmployee().Find(emp => emp.EmployeeID == id));
        }


    }
}*/
