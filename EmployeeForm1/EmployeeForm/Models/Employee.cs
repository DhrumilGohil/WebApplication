using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
        public int PresentTalukaID { get; set; }
        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Present Pincode is required.")]
        [Display(Name = "Present Pincode")]
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
       
        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]        
        [Display(Name = "Date Of Birth")]
        public System.DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Join")]
        [Required(ErrorMessage = "Date of join is required.")]
        public System.DateTime Dateofjoin { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Retirement")]
        public System.DateTime DateofRetirement { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "District Join Date")]
        [Required(ErrorMessage = "District Join Date Birth is required.")]        
        public System.DateTime DistrictJoiningDate { get; set; }
        [Display(Name = "Employee Entry in District")]
        [Required(ErrorMessage = "Employee Entry Date is required.")]
        public string EmployeeEntryinDistrict { get; set; }
        [Required(ErrorMessage ="Select AgencyID")]
        public string EmployeeType { get; set; }
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
        public int CardeID { get; set; }
        public int DesignationID { get; set; }
        public int ApprovedVacancies { get; set; }
        public int FilledVacancies { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
}

    public class Cardes
        {
        public int CardesID { get; set; }
        [Display(Name ="Cardes Name")]
        public string CardesName { get; set; }
        [Display(Name = "Cardes By")]
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        }
    public class Agency
    {
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Office
    {
        public int OfficeID { get; set; }
        public string OfficeName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class EmpDesignation
    {
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class District
    {
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class EmployeeJobDetail
    {
        public int EmpJobID { get; set; }
        public string EmployeeID { get; set; }
        public int DistrictID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime FromTo { get; set; }
        public int OfficeID { get; set; }
        public string PlaceName { get; set; }
    }
    public class Taluka
    {
        public int TalukaID { get; set; }
        public string TalukaName { get; set; }
        public int DistrictID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class Exam
    {
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public int DistrictID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
    public class EmployeeExam
    {
        public int EmployeeID { get; set; }
        public string ExamID { get; set; }
        public int PassingDate { get; set; }
        public string NumberOfAttempt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class Login
    {
        public int LoginID { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public int Password { get; set; }
    }

    public enum EmpType
    {
        Goverment,
        [Description("Non-Goverment")]
        NonGoverment
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

    public enum Designation
    {
        Collector,
        RAC,
        ARDC,
        Choose,
        Chitnis,
        [Description("Adhik Chitnis")]
        AdhikChitnis,
        [Description("PRO to Collector")]
        PROtoCollector,
        [Description("Exam Chitnis")]
        ExamChitnis,
        [Description("Prant Officer")]
        Prantofficer,
        Mamlatdar,
        [Description("Ad. District Election Officer")]
        AdDistrictElectionOfficer,
        [Description("DistrictSupplyofficer")]
        DistrictSupplyofficer,
        [Description("District Planning officer")]
        DistrictPlanningofficer,
        [Description("Dy. Collector")]
        DyCollector,
        [Description("Addition Special L.A.O.")]
        AdditionSpecialLAO,
        [Description("Second L.A.O.")]
        SecondLAO,
        [Description("Deputy Director")]
        DeputyDirector, 
        Talati,
        Clerk,
        Accountant,
        [Description("Data-Entry Operator")]
        DataEntryOperator,
        [Description("Officer Boy")]
        OfficerBoy
    }
    public enum Department
    {
        [Description("  Collector Officer")]
        CollectorOfficer,
        Munacipality,
        Legal,
        DUDA,
        [Description(" Entertainment Tax")]
        EntertainmentTax,
        [Description("Alien Recovery")]
        AlienRecovery,
        Maninagar,
        Asarva,
        Vatva,
        Vejalpur,
        Ghatalodiya,
        Sabarmati,
        Dascroi,
        Sanand,
        Dholka,
        Bavla,
        Dhandhuka,
        Dholera,
        Viramgam,
        Mandal,
        DCLR,
        [Description("N/A")]
        NA,
        Election,
        [Description("Sardarnagar Township")]
        SardarnagarTownship,
        [Description("LAO-ONGC")]
        LAOONGC,
        [Description("Stamp Duty-1")]
        StampDuty1,
        [Description("Stamp Duty-2")]
        StampDuty2,
        [Description("Small Saving")]
        SmallSaving,
        [Description("Asarva Mamlatdar Ext.")]
        AsarvaMamlatdarExt,
        [Description("Dariyapur-Kalupur Mamlatdar Ext.")]
        DariyapurKalupurMamlatdarExt,
        [Description(" Naroda-Nikol Mamlatdar Ext.")]
        NarodaNikolMamlatdarExt,
        [Description(" Danilimda Mamlatdar Ext.")]
        DanilimdaMamlatdarExt,
        [Description("Khokhra-Memdabad Mamlatdar Ext.")]
        KhokhraMemdabadMamlatdarExt,
        [Description("Rajpur-Hirpur Mamlatdar Ext.")]
        RajpurHirpurMamlatdarExt,
        [Description(" Rakhiyal Mamlatdar Ext.")]
        RakhiyalMamlatdarExt,
        [Description(" Vastral MamlatdarExt.")]
        VastralMamlatdarExt,
        [Description("Vatava Mamlatdar Ext.")]
        VatavaMamlatdarExt,
        [Description("Acher Mamlatdar Ext.")]
        AcherMamlatdarExt,
        [Description(" Paladi Mamlatdar Ext.")]
        PaladiMamlatdarExt,
        [Description(" Vadaj Mamlatdar Ext.")]
        VadajMamlatdarExt,
        [Description(" Sola Mamlatdar Ext.")]
        SolaMamlatdarExt,
        [Description("Thaltej Mamlatdar Ext.")]
        ThaltejMamlatdarExt,
        [Description("Vejalpur Mamlatdar Ext.")]
        VejalpurMamlatdarExt,
        [Description("Sarkhej Mamlatdar Ext.")]
        SarkhejMamlatdarExt,
    }
}
