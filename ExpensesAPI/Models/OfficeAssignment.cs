using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesAPI.Models
{
    public class OfficeAssignment
    {
        [ForeignKey("SummerField")]
        public int OfficeAssignmentId { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

  
        public virtual SummerField SummerField { get; set; }
    }
}