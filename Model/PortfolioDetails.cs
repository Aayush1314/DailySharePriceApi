using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailySharePriceApi.Model
{
    public class PortfolioDetails
    {
        [Key]
        public int PortfolioId { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        





    }
}
