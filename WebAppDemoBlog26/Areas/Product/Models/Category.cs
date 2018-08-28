using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebAppDemoBlog26.Common;

namespace WebAppDemoBlog26.Areas.Product.Models
{
    [MetadataType(typeof(CategoryMetaData))]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = Convert.ToDateTime("2015/01/01");
        public DateTime HireDate { get; set; } = Convert.ToDateTime("2015/01/01");

        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
    }

    public class CategoryMetaData
    {
        [StringLength(10,MinimumLength =5)]
        [Required]
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage ="regex violated")]
        public string Name { get; set; }

        [Display(Name ="Created Date")]
        [DateRangeOneYearBackAttribute("2010/10/01")]
        [DisplayFormat(DataFormatString ="{0:d}",ApplyFormatInEditMode =true)]
        public DateTime CreatedDate { get; set; }

        [Display(Name ="Hire Date")]
        [CurrentDateValidate(ErrorMessage ="Hire date must be today or an older date")]
        public DateTime HireDate { get; set; }

        [EmailAddress(ErrorMessage ="not a valid email")]
        public string Email { get; set; }

        [Display(Name ="Confirm Email")]
        [Compare("Email")]
        [EmailAddress(ErrorMessage = "not a valid email")]
        public string ConfirmEmail { get; set; }
    }
}