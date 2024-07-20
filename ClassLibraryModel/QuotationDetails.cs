using System.ComponentModel.DataAnnotations;

namespace ClassLibraryModel
{
    public class QuotationDetails
    {
        public QuotationDetails()
        {
            Items = new List<ItemDetails>();
            Guid obj = Guid.NewGuid();
            string gid = obj.ToString();
            Console.WriteLine(obj);
            string[] words = gid.Split("-");
            
            QuotationId = words[0];

        }

        [Key]
        public string? QuotationId { get; set; }
        [Required]
        public long? CustomerMobile { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? Remarks { get; set; }
        [Required]
        public float TotalAmount { get; set; }

        public List<ItemDetails> Items { get; set; }
    }
}