using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BasicMVCProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{yyyy-mm-ddT00:00:00.00}")]
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Discipline { get; set; }
        public string Address { get; set; }
        
    }
}
