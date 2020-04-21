using System.Collections.Generic;
using Bogus;
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


            modelBuilder.Entity<User>().HasMany(user => user.Articles).WithOne(article => article.User);
            modelBuilder.Entity<User>().HasMany(user => user.Reviews).WithOne(review => review.User);
            modelBuilder.Entity<Article>().HasMany(article => article.Comments).WithOne(articleComment => articleComment.Article);
            modelBuilder.Entity<Product>().HasMany(product => product.Tags ).WithOne(tag => tag.Product);
            modelBuilder.Entity<Product>().HasMany(product => product.Reviews ).WithOne(review => review.Product);
            modelBuilder.Entity<Product>().HasMany(product => product.Images ).WithOne(productImages => productImages.Product);
            modelBuilder.Entity<Category>().HasMany(category => category.Products ).WithOne(product => product.Category);
            modelBuilder.Entity<Order>().HasMany(order => order.OrderHasProducts ).WithOne(orderHasProduct => orderHasProduct.Order);
            // one-to-one
            modelBuilder.Entity<User>().HasOne(user => user.UserDetail).WithOne(userDetail => userDetail.User);
            this.TestData(modelBuilder);
        }

        private void TestData(ModelBuilder modelBuilder)
        {

            int numberUsers = 15;
            int numberCategories = 5;
            int numberSellers = 5;
            int numberProducts = 100;
            int numberOrders = 50;
            int numberArticles = 40;
            
            
            
                var testUserDetail = new Faker<UserDetail>().RuleFor(u => u.UserDetailId, (f, u) => f.IndexFaker + 1 )
                    .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName())
                    .RuleFor(u => u.LastName, (f, u) => f.Name.LastName())
                    .RuleFor(u => u.ContactEmail, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                    .RuleFor(u => u.Address, (f, u) => f.Address.StreetAddress())
                    .RuleFor(u => u.City, (f, u) => f.Address.City())
                    .RuleFor(u => u.Country, (f, u) => f.Address.Country())
                    .RuleFor(u => u.ZipCode, (f, u) => f.Address.ZipCode());

                List<UserDetail> userDetails = testUserDetail.Generate(numberUsers);
                modelBuilder.Entity<UserDetail>().HasData(userDetails);


                var testUser = new Faker<User>().RuleFor(u => u.UserId, (f, u) => f.IndexFaker + 1)
                    .RuleFor(u => u.UserDetailId, (f, u) => userDetails[f.IndexFaker].UserDetailId)
                    .RuleFor(u => u.Email, (f, u) => f.Internet.Email())
                    .RuleFor(u => u.PasswordHash, (f, u) => f.Random.Hash());
                List<User> useres = testUser.Generate(numberUsers);
                modelBuilder.Entity<User>().HasData(useres);

                var testCategory = new Faker<Category>().RuleFor(c => c.CategoryId, (f, c) => f.IndexFaker + 1)
                    .RuleFor(c => c.Name, (f, c) => f.Commerce.Categories(1)[0]);

                List<Category> categories = testCategory.Generate(numberCategories);
                modelBuilder.Entity<Category>().HasData(categories);
                
                var testSeller = new Faker<Seller>().RuleFor(s => s.SellerId, (f, s) => f.IndexFaker +1)
                    .RuleFor(s => s.Name, (f, s) => f.Company.CompanyName());
                
                List<Seller> sellers = testSeller.Generate(numberSellers);
                modelBuilder.Entity<Seller>().HasData(sellers);

                var testProduct = new Faker<Product>().RuleFor(p => p.ProductId, (f, p) => f.IndexFaker + 1)
                    .RuleFor(p => p.CategoryId, (f, p) => f.PickRandom(categories).CategoryId)
                    .RuleFor(p => p.SellerId, (f, p) => f.PickRandom(sellers).SellerId)
                    .RuleFor(p => p.Name, (f, p) => f.Commerce.ProductName())
                    .RuleFor(p => p.Description, (f, p) => f.Lorem.Text())
                    .RuleFor(p => p.Number, (f, p) => f.Random.Number())
                    .RuleFor(p => p.Price, (f, p) => f.Finance.Amount())
                    .RuleFor(p => p.Sale,
                        (f, p) => f.Random.Number(max: 5) == 1 ? f.Finance.Amount(p.Price / 2, p.Price) : 0)
                    .RuleFor(p => p.CreatedAt,
                        (f, p) => f.Random.Number(max: 4) == 1 ? f.Date.Past() : f.Date.Recent());
                
                List<Product> products = testProduct.Generate(numberProducts);
                modelBuilder.Entity<Product>().HasData(products);

                var testProductImage = new Faker<ProductImage>()
                    .RuleFor(p => p.ProductImageId, (f, p) => f.IndexFaker + 1)
                    .RuleFor(p => p.ProductId, (f, p) => products[f.IndexFaker].ProductId)
                    .RuleFor(p => p.Image, (f, p) => f.Image.LoremFlickrUrl());
                List<ProductImage> productImages = testProductImage.Generate(numberProducts);
                modelBuilder.Entity<ProductImage>().HasData(productImages);

                var testTag = new Faker<Tag>()
                    .RuleFor(t => t.TagId, (f, t) => f.IndexFaker + 1)
                    .RuleFor(t => t.ProductId, (f, t) => f.PickRandom(products).ProductId)
                    .RuleFor(t => t.Name, (f, t) => f.Random.String());
                List<Tag> tags = testTag.Generate(numberProducts*2);
                modelBuilder.Entity<Tag>().HasData(tags);

                var testReview = new Faker<Review>()
                    .RuleFor(r => r.ReviewId, (f, r) => f.IndexFaker + 1)
                    .RuleFor(r => r.UserId, (f, r) => f.PickRandom(useres).UserId)
                    .RuleFor(r => r.ProductId, (f, r) => f.PickRandom(products).ProductId)
                    .RuleFor(r => r.Stars, (f, r) => f.Random.Number(max: 5))
                    .RuleFor(r => r.Content, (f, r) => f.Lorem.Text());
                List<Review> reviews = testReview.Generate(numberProducts*2);
                modelBuilder.Entity<Review>().HasData(reviews);

                var testOrder = new Faker<Order>()
                    .RuleFor(o => o.OrderId, (f, o) => f.IndexFaker + 1)
                    .RuleFor(o => o.UserDetailId, (f, o) => f.PickRandom(userDetails).UserDetailId)
                    .RuleFor(o => o.CreatedAt, (f, o) => f.Date.Past())
                    .RuleFor(o => o.FirstName, (f, o) => f.Name.FirstName())
                    .RuleFor(o => o.LastName, (f, o) => f.Name.LastName())
                    .RuleFor(o => o.ContactEmail, (f, o) => f.Internet.Email(o.FirstName, o.LastName))
                    .RuleFor(o => o.Address, (f, o) => f.Address.StreetAddress())
                    .RuleFor(o => o.City, (f, o) => f.Address.City())
                    .RuleFor(o => o.Country, (f, o) => f.Address.Country())
                    .RuleFor(o => o.ZipCode, (f, o) => f.Address.ZipCode());
                List<Order> orders = testOrder.Generate(numberOrders);
                modelBuilder.Entity<Order>().HasData(orders);

                var testOrderHasProduct = new Faker<OrderHasProduct>()
                    .RuleFor(o => o.OrderHasProductId, (f, o) => f.IndexFaker + 1)
                    .RuleFor(o => o.OrderId, (f, o) => orders[f.IndexFaker].OrderId)
                    .RuleFor(o => o.ProductId, (f, o) => f.PickRandom(products).ProductId)
                    .RuleFor(o => o.Number, (f, o) => f.Random.Number())
                    .RuleFor(o => o.PriceTotal,
                        (f, o) => products.Find(p => p.ProductId == o.ProductId)!.Price * o.Number);
                List<OrderHasProduct> orderHasProducts = testOrderHasProduct.Generate(numberOrders);
                modelBuilder.Entity<OrderHasProduct>().HasData(orderHasProducts);

                var testArticle = new Faker<Article>()
                    .RuleFor(a => a.ArticleId, (f, a) => f.IndexFaker + 1)
                    .RuleFor(a => a.UserId, (f, a) => f.PickRandom(useres).UserId)
                    .RuleFor(a => a.Name, (f, a) => f.Lorem.Word())
                    .RuleFor(a => a.Content, (f, a) => f.Lorem.Text())
                    .RuleFor(a => a.Image, (f, a) => f.Image.LoremFlickrUrl())
                    .RuleFor(a => a.CreatedAt, (f, a) => f.Date.Past());
               
                List<Article> articles = testArticle.Generate(numberArticles);
                modelBuilder.Entity<Article>().HasData(articles);
                
                var testArticleComment = new Faker<ArticleComment>()
                    .RuleFor(a => a.ArticleCommentId, (f, a) => f.IndexFaker + 1)
                    .RuleFor(a => a.ArticleId, (f, a) => f.PickRandom(articles).ArticleId)
                    .RuleFor(a => a.UserId, (f, a) => f.PickRandom(useres).UserId)
                    .RuleFor(a => a.Content, (f, a) => f.Lorem.Text())
                    .RuleFor(a => a.CreatedAt, (f, a) => f.Date.Past());
                    
                List<ArticleComment> articleComments = testArticleComment.Generate(numberArticles*3);
                modelBuilder.Entity<ArticleComment>().HasData(articleComments);



        }
    }
}