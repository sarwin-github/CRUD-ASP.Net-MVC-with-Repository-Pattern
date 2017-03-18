using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest.Domain.Entities
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public int Age { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        public string Department { get; set; }
    }
}
