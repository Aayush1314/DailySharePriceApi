using System.ComponentModel.DataAnnotations;

namespace DailySharePriceApi.Model
{
    public class MutualFundPriceDetails
    {
        [Key]
        public int MutualFundId { get; set; }

        [Required]
        public string MutualFundName { get; set; }
        
        [Required]
        public int MutualFundPrice { get; set;}
    }
}
