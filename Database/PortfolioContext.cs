using DailySharePriceApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DailySharePriceApi.Models
{
    public class PortfolioContext : DbContext 
    {
        public DbSet<StockPriceDetails> StockPriceDetails { get; set; }

    
        public DbSet<MutualFundDetails> mutualFundDetails { get; set;}
        public DbSet<MutualFundPriceDetails> mutualFundPriceDetails { get; set; }
        public DbSet<PortfolioDetails> portfolioDetails { get; set; }   
        public DbSet<StockDetails> stockDetails { get; set; }

        public PortfolioContext(DbContextOptions<PortfolioContext> options)
            : base(options)
        { }
    }
}
