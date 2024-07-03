using System.ComponentModel.DataAnnotations;

namespace ClassLibraryModel
{
    public class Quotation
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string QTNumber { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Address { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public string Remarks { get; set; }
        [Required]
        public float TotalAmount {  get; set; }
        public List<ItemDetails> Items { get; set; } = new List<ItemDetails>();

    }
}