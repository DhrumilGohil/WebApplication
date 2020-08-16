using EmployeeForm.Models;
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
using PagedList;
using PagedList.Mvc;
using System.Web.UI;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult GetRetireEmp()
        {
            return View();
        }
        // GET: Employee
        public ActionResult ShowAllEmployee(int? page, string Search)
        {
            EmpRepository EmpRepo = new EmpRepository();
            ModelState.Clear();
            List<Employee> test = new List<Employee>();
            test = EmpRepo.GetAllEmployee(0).ToList();
            if (Search != null) {
                test = test.Where(x => x.FirstName.Contains(Search) || x.LastName.Contains(Search)).ToList();
            }
            return View(test.ToPagedList(page ?? 1, 3));
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
            List<Employee> EditEmployee = new List<Employee>();
            EditEmployee = Emprepo.GetAllEmployee(id);
            ViewBag.PdId = EditEmployee[0].PresentDistrictID;
            ViewBag.PtId = EditEmployee[0].PresentTalukaID;
            ViewBag.NdId = EditEmployee[0].NativeDistrictID;
            ViewBag.NtId = EditEmployee[0].NativeTalukaID;
            ViewBag.AgencyId = EditEmployee[0].AgencyID;
            ViewBag.Gender = EditEmployee[0].Gender;
            ViewBag.EmployeeType = EditEmployee[0].EmployeeType;
            ViewBag.Doj = EditEmployee[0].Dateofjoin;
            return View(EditEmployee);
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
            List<District> Districts = Emprepo.GetAllDistrict().ToList();
            return Json(Districts, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllTalukas([Optional] int Empid)
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Taluka> Talukas = Emprepo.GetAllTaluka(Empid);
            return Json(Talukas, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAllAgencies()
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Agency> Agencies = Emprepo.GetAllAgency();
            return Json(Agencies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllEmployeeName()
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Employee> NameEmployee = Emprepo.GetAllEmployee(0).ToList();
            return Json(NameEmployee, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult search(string Search)
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Employee> test = new List<Employee>();
            test = Emprepo.GetAllEmployee();
            return View(test.Where(x => x.FirstName.Contains(Search)).ToList());
        }

        public ActionResult MehkamDetail()
        {
            return View();
        }

        public ActionResult AddCadres()
        {
            return View();
        }
        public ActionResult ListOfCadres()
        {
            EmpRepository Emprepo = new EmpRepository();
            return View(Emprepo.ListCadres());
        }
        public ActionResult AddAgency()
        {
            return View();
        }       
        [HttpPost]
        public ActionResult AddAgency(Agency age)
        {
            EmpRepository Emprepo = new EmpRepository();
            if (Emprepo.addAgency(age))
            {
                return RedirectToAction("ShowAllemployee");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
        public ActionResult ListOfAgency()
        {
            EmpRepository Emprepo = new EmpRepository();
            return View(Emprepo.ListAgency());
        }
        public ActionResult EmployeeJobDetails()
        {
            return View();
        }

        public JsonResult GetCadresName()
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Cadres> GetAllnames = new List<Cadres>();
            GetAllnames = Emprepo.ListCadres();
            return Json(GetAllnames, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDesignationName()
        {
            EmpRepository Emprepo = new EmpRepository();
            List<EmpDesignation> GetAllnames = new List<EmpDesignation>();
            GetAllnames = Emprepo.ListDesignation();
            return Json(GetAllnames, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Taluka()
        {
            return View();
        }
        public ActionResult District()
        {
            return View();
        }

        public ActionResult AddExam()
        {
            return View();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        }
        public ActionResult ListofExam()
        {
            EmpRepository Emprepo = new EmpRepository();
            return View(Emprepo.ListExam());
        }
        public ActionResult EmployeeExam()
        {
            return View();
        }
        public JsonResult GetExamName()
        {
            EmpRepository Emprepo = new EmpRepository();
            List<Exam> GetAllnames = new List<Exam>();
            GetAllnames = Emprepo.ListExam();
            return Json(GetAllnames, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Office()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddDesignation()
        {
            return View();
        }
        public ActionResult ListofDesignation()
        {
            EmpRepository Emprepo = new EmpRepository();
            return View(Emprepo.ListDesignation());
        }
        public ActionResult ShowListDistrict(int? page)
        {
            EmpRepository Emprepo = new EmpRepository();
            return View(Emprepo.AllDistricsDetail().ToPagedList(page ?? 1, 10));
        }
        public ActionResult ShowListTaluka(int? page)
        {
            EmpRepository Emprepo = new EmpRepository();
            return View(Emprepo.AllTalukasDetail().ToPagedList(page ?? 1,10));
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
