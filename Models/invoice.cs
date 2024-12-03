using Microsoft.VisualBasic;

namespace mvc.Models
{
    public class invoice
    {
        public int invoiceno { get; set; }
        public DateTime date { get; set; }
        public required string customername { get; set; }
        public required int Areaid { get; set; }
        public required string description { get; set; }
        public required string batchno { get; set; }
        public required int quantity { get; set; }
        public required decimal price { get; set; }
        public required decimal discount1 { get; set; }
        public required decimal discount2 { get; set; }
        public required decimal addtax { get; set; }
        public required DateTime expirydate { get; set; }
        public required string address { get; set; }
        public bool mdelete { get; set; }


    }
}
