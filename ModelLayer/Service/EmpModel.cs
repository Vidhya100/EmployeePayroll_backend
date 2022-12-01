using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service
{
    public class EmpModel
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string ProfileImg { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
