using Microsoft.EntityFrameworkCore;

namespace RobinEshop.Models
{
    
    public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {
            
        }
    }
}