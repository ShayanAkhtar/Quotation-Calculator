using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class SkyPenDetails
    {
        public int Id { get; set; }
        public float ProfileCode { get; set; }
        public string ProfileFunction { get; set; }
        public float WhiteWithoutGasket { get; set; }
        public float WhiteWithCoexGasket { get; set; }
        public float WhiteWithTPVGasket { get; set; }
        public float TBAndTDOWithTPVGasket { get; set; }
    }
}
