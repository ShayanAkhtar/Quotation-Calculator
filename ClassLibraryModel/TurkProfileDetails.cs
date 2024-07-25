using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class TurkProfileDetails
    {
        public int Id {  get; set; }
        public float ProfileCode { get; set; }
        public string ProfileFunction { get; set; }
        public float WhiteWithoutGasket { get; set; }
        public float WhiteWithGasket { get; set; }
        public float BlackSolidColor { get; set; }
    }
}
