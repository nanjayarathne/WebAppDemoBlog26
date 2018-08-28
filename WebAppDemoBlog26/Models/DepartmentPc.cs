using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebAppDemoBlog26.Models
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial  class Department
    {

    }

    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {

    }

    public partial class DepartmentMetaData
    {
       
        [Display(Name ="Department Name")]
        public string Name { get; set; }
        [Display(Name = "Department")]
        public int Id { get; set; }
    }
    public partial class EmployeeMetaData
    {
        [Required]
        [Remote("IsNameEnable", "Employees", ErrorMessage = "already in use")]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Display(Name ="Department")]
        [Required]
        public Nullable<int> DepartmentId { get; set; }

    }

}