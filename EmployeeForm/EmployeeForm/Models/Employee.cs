using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeForm.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [RegularExpression("^([a-zA-Z]+)$" , ErrorMessage = "Invalid First Name")]
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Invalid First Name")]

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Invalid Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender check is  required.")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please Enter your valid email which contains the @ Sign")]
        [Required(ErrorMessage = "Email ID is required.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Present Address is required.")]
        [Display(Name = "Present Address")]
        public string PresentAddress { get; set; }
        [Required(ErrorMessage = "Present DistrictID is required.")]
        [Display(Name = "Present DistrictID")]
        public int PresentDistrictID { get; set; }
        [Required(ErrorMessage = "Present TalukaID is required.")]
        [Display(Name = "Present TalukaID")]

        public string DistrictName { get; set; }
        public int PresentTalukaID { get; set; }
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Present Pincode is required.")]
        [Display(Name = "Present Pincode")]

        public string TalukaName { get; set; }
        public int PresentPINCODE { get; set; }

        [Display(Name = "Native Address")]
        public string NativeAddress { get; set; }
        [Required(ErrorMessage = "Native DistrictID is required.")]
        [Display(Name = "Native DistrictID")]
        public int NativeDistrictID { get; set; }
        [Required(ErrorMessage = "Native TalukaID is required.")]
        [Display(Name = "Native TalukaID")]

        public int NativeTalukaID { get; set; }
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Native Pincode is required.")]
        [Display(Name = "Native Pincode")]
        public int NativePINCODE { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        
        public string AlternatePhoneNumber { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        [Required(ErrorMessage = "Emeregency Phone Number is required.")]
        [Display(Name = "Emeregency Number")]
        public string EmergencyContactNumber { get; set; }
        [Required(ErrorMessage = "Enter Emergency Contact Name")]
        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-DD hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date of Birth is required.")]        
        [Display(Name = "Date Of Birth")]
        public System.DateTime DateOfBirth { get; set; }
        [Display(Name = "Date Of Join")]
        [Required(ErrorMessage = "Date of join is required.")]
        public System.DateTime Dateofjoin { get; set; }

        [Display(Name = "Date Of Retirement")]
        public System.DateTime DateofRetirement { get; set; }
        [Display(Name = "District Join Date")]
        [Required(ErrorMessage = "District Join Date Birth is required.")]        
        public System.DateTime DistrictJoiningDate { get; set; }
        [Display(Name = "Employee Entry in District")]
        [Required(ErrorMessage = "Employee Entry Date is required.")]
        public string EmployeeEntryinDistrict { get; set; }
        [Required(ErrorMessage = "Select EmployeeType")]
        public string EmployeeType { get; set; }
        [Required(ErrorMessage = "Select AgencyID")]
        public int AgencyID { get; set; }
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
        [Display(Name = "Is Active")]
        public bool isActive { get; set; }
        
    }

    public class MehkamDetail
    {
        public int MehkamID { get; set; }
        [Display(Name ="Cadres ID")]
        public int CardesID { get; set; }
        [Display(Name = "Designation ID")]
        public int DesignationID { get; set; }
        [Display(Name = "Approve Vacancies")]
        public int ApprovedVacancies { get; set; }
        [Display(Name = "Filled Vacancies")]
        public int FilledVacancies { get; set; }
        [Display(Name = "Remark")]
        public string Remarks { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated By")]
        public int UpdatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
}

    public class Cadres
        {
        public int CadresID { get; set; }
        [Display(Name ="Cadres Name")]
        public string CadresName { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        }
    public class Agency 
    {
        public int AgencyID { get; set; }
        [Display(Name = "Agency Name")]
        public string AgencyName { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
    public class Office
    {
        public int OfficeID { get; set; }
        [Display(Name = "Office Name")]
        public string OfficeName { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
    public class EmpDesignation
    {
        public int DesignationID { get; set; }
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
    public class District
    {
        public int DistrictID { get; set; }
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }

    public class EmployeeJobDetail
    {
        public int EmpJobID { get; set; }
        [Display(Name = "Employee ID")]
        public string EmployeeID { get; set; }
        [Display(Name = "District ID")]
        public int Designation { get; set; }
        [Display(Name = "Craeted By")]
        public string CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }
        [Display(Name = "From To")]
        [DataType(DataType.Date)]
        public DateTime FromTo { get; set; }
        [Display(Name = "Office ID")]
        public int OfficeID { get; set; }
        [Display(Name = "Place Name")]
        public string PlaceName { get; set; }
    }
    public class Taluka
    {
        public int TalukaID { get; set; }
        [Display(Name = "Taluka Name")]
        public string TalukaName { get; set; }
        [Display(Name = "District ID")]
        public int DistrictID { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Exam
    {
        public int ExamID { get; set; }
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Updated By")]
        public int UpdatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
    }
    public class EmployeeExam
    {
        public int EmployeeID { get; set; }
        [Display(Name = "Exam ID")]
        public string ExamID { get; set; }
        [Display(Name = "Passing Date")]
        [DataType(DataType.Date)]
        public DateTime PassingDate { get; set; }
        [Display(Name = "Number of attempt")]
        public int NumberOfAttempt { get; set; }
        [Display(Name = "Created By")]
        public int CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }

    public class Login
    {
        public int LoginID { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public int Password { get; set; }
    }
    public class CustomerEditViewModel
    {
        [Display(Name = "Customer Number")]
        public string CustomerID { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        [StringLength(75)]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Country")]
    
        public IEnumerable<SelectListItem> Countries { get; set; }

        [Required]
        [Display(Name = "State / Region")]
    
        public IEnumerable<SelectListItem> Regions { get; set; }
    }

public enum EmpType
    {
        Goverment = 1,
        [Description("Non-Goverment")]
        NonGoverment = 2
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public enum EmployeeEntry
    {
         Promotion,
         Direct_Recruitment,
         District_Transfer
    }

}
