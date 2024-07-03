using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ItemDetails
    {
        public string Type {get; set;}
        public float Width {get; set;}
        public float Height {get; set;}
        public float SQFT {get; set;}
        public float W3 {get; set;}
        public float H3 {get; set;}
        public float W6 {get; set;}
        public float H6 {get; set;}
        public float SQFT3 {get; set;}
        public float SQFT6 {get; set;}
        public GlassDetails Glass {get; set;}
        public float WindowsAmount {get; set;}
        public float GlassAmount {get; set;}
    }
}
