using System.ComponentModel.DataAnnotations;

namespace DailySharePriceApi.Model
{
    public class StockPriceDetails
    {
        [Key]
        public int StockId { get; set; }
        
        [Required]
        public string StockName { get; set; }
        
        [Required]
        public decimal StockPrice { get; set; }
    }
}
