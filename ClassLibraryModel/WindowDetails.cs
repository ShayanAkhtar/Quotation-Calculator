using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class WindowDetails
    {
        [Key]
        public int WindowsId { get ; set; }
        public string? Type { get; set; }
        public float Rate {  get; set; }
    }
}
