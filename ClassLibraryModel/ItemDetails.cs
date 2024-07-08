using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModel
{
    public class ItemDetails
    {
        public ItemDetails()
        {
            Glass = new GlassDetails();
            Window = new WindowDetails();
            QTY = 1;
        }

        [Key]
        public int ItemId { get; set; }
        public int GlassId { get; set; }
        [ForeignKey("GlassDetailsId")]
        public GlassDetails Glass { get; set; }
        [ForeignKey("QuotationDetails")]
        public string QuotationId { get; set; }
        public QuotationDetails QuotationDetails { get; set; }
        public int WindowsId { get; set; }
        [ForeignKey("WindowsId")]
        public WindowDetails? Window { get; set; }
        public float Width {get; set;}
        public float Height {get; set;}
        public float SQFT {get; set;}
        public float W3 {get; set;}
        public float H3 {get; set;}
        public float W6 {get; set;}
        public float H6 {get; set;}
        public float SQFT3 {get; set;}
        public float SQFT6 {get; set;}
        public float WindowsRate { get; set; }
        public float GlassRate { get; set; }
        public float WindowsAmount {get; set;}
        public float GlassAmount {get; set;}
        public int QTY { get; set;}
    }
}
