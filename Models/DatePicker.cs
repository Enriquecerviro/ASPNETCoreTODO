using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTodo.Models
{
    public class DatePicker
    {
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
    }
}
