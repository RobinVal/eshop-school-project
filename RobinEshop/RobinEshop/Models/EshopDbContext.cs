using Microsoft.EntityFrameworkCore;

namespace RobinEshop.Models
{
    
    public class EshopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderHasProduct> OrderHasProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        
        public EshopDbContext(DbContextOptions<EshopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<Seller>().HasIndex(seller => seller.Name).IsUnique();
            modelBuilder.Entity<ProductImage>().HasIndex(productImage => productImage.Image).IsUnique();
            modelBuilder.Entity<Tag>().HasIndex(tag => tag.Name).IsUnique();
// Vzor -- public ICollection<ArticleComment> Comments { get; set; }

            modelBuilder.Entity<User>().HasMany(user => user.Articles).WithOne(article => article.User);
            modelBuilder.Entity<User>().HasMany(user => user.Reviews).WithOne(review => review.User);
            modelBuilder.Entity<Article>().HasMany(article => article.Comments).WithOne(articleComment => articleComment.Article);
            modelBuilder.Entity<Product>().HasMany(product => product.Tags ).WithOne(tag => tag.Product);
            modelBuilder.Entity<Product>().HasMany(product => product.Reviews ).WithOne(review => review.Product);
            modelBuilder.Entity<Product>().HasMany(product => product.Images ).WithOne(productImages => productImages.Product);
            modelBuilder.Entity<Category>().HasMany(category => category.Products ).WithOne(product => product.Category);
            // one-to-one
            modelBuilder.Entity<User>().HasOne(user => user.UserDetail).WithOne(userDetail => userDetail.User);
            
            
            
        }
    }
}