using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class CustomerDetails
    {
        [Required]
        public string? CustomerName { get; set; }
        public string? Address { get; set; }
        [Required]
        public string? MobileNumber { get; set; }
    }
}
