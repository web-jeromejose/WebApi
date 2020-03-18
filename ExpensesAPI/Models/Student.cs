using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpensesAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CurrentGradeId { get; set; }
        public Grade CurrentGrade { get; set; }
    }
}