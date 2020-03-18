using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExpensesAPI.Models
{

    public enum Gradeenum
    {
        A, B, C, D, F
    }

    public class SummerField
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Block { get; set; }
        public string Lot { get; set; }
        public string Owner { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Full House Name ")]
        public string FullHouseName
        {
            get { return Block + ", " + Lot; }
        }

        //enum
        [DisplayFormat(NullDisplayText = "No grade")]
        public Gradeenum? Grade { get; set; }

        //many to one 
 
        public  virtual OfficeAssignment OfficeAssignment { get; set; }

        //many to many
        //public ICollection<CourseAssignment> CourseAssignments { get; set; }

    }
}