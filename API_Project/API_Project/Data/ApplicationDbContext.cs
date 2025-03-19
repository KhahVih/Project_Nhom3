using API_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryImage> CategoryImages { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerHistory> CustomerHistories { get; set; } = null!;
        public virtual DbSet<FrontendLayout> FrontendLayouts { get; set; } = null!;
        public virtual DbSet<FrontendLayoutImage> FrontendLayoutImages { get; set; } = null!;
        public virtual DbSet<History> Histories { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<ImageProduc> ImageProduc { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderSale> OrderSales { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductDetail> ProductDetails { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Seeding> Seedings { get; set; } = null!;
        public virtual DbSet<Size> Sizes { get; set; } = null!;
        public virtual DbSet<Suggest> Suggests { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WebConfig> WebConfigs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageProduc>(entity =>
            {
                entity.HasKey(ip => new { ip.ImageId, ip.ProductId });

                entity.HasOne(ip => ip.Image)
                .WithMany(p => p.ImageProducs)
                .HasForeignKey(ip => ip.ImageId);

                entity.HasOne(ip => ip.Product)
                .WithMany(p => p.ImageProducs)
                .HasForeignKey(ip => ip.ProductId);
            });
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Body).HasColumnType("text");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Blogs_Categories");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Blogs_Images");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CategoryImage>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(500);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comments_Customers");

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Comments)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductComment",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK_ProductComment_Products"),
                        r => r.HasOne<Comment>().WithMany().HasForeignKey("CommentId").HasConstraintName("FK_ProductComment_Comments"),
                        j =>
                        {
                            j.HasKey("CommentId", "ProductId");

                            j.ToTable("ProductComment");
                        });
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Phonenumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<CustomerHistory>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerHistories)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CustomerHistories_Customers");
            });

            modelBuilder.Entity<FrontendLayoutImage>(entity =>
            {
                entity.HasKey(e => new { e.FrontendLayoutId, e.ImageId });

                entity.ToTable("FrontendLayoutImage");

                entity.HasOne(d => d.FrontendLayout)
                    .WithMany(p => p.FrontendLayoutImages)
                    .HasForeignKey(d => d.FrontendLayoutId)
                    .HasConstraintName("FK_FrontendLayoutImage_FrontendLayouts");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.FrontendLayoutImages)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_FrontendLayoutImage_Images");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("History");

                entity.Property(e => e.Datetime).HasColumnType("datetime");

                entity.Property(e => e.Ip).HasColumnName("IP");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Size).HasMaxLength(50);

                entity.HasOne(d => d.Categor)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.CategorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Images_Categories");

                entity.HasOne(d => d.CategoryImage)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.CategoryImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Images_CategoryImages");
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Orders_Customers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PosCode).HasMaxLength(50);

                entity.Property(e => e.Size).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetails_Orders");
            });

            modelBuilder.Entity<OrderSale>(entity =>
            {
                entity.ToTable("OrderSale");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Permistions)
                    .UsingEntity<Dictionary<string, object>>(
                        "PermissionRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_PermistionRole_Roles"),
                        r => r.HasOne<Permission>().WithMany().HasForeignKey("PermistionId").HasConstraintName("FK_PermistionRole_Permisions"),
                        j =>
                        {
                            j.HasKey("PermistionId", "RoleId").HasName("PK_PermistionRole");

                            j.ToTable("PermissionRole");
                        });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasMany(d => d.Blogs)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductBlog",
                        l => l.HasOne<Blog>().WithMany().HasForeignKey("BlogId").HasConstraintName("FK_ProductBlog_Blogs"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK_ProductBlog_Products"),
                        j =>
                        {
                            j.HasKey("ProductId", "BlogId");

                            j.ToTable("ProductBlog");
                        });

                entity.HasMany(d => d.Catefories)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CateforyId").HasConstraintName("FK_ProductCategory_Categories"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").HasConstraintName("FK_ProductCategory_Products"),
                        j =>
                        {
                            j.HasKey("ProductId", "CateforyId");

                            j.ToTable("ProductCategory");
                        });
            });

            modelBuilder.Entity<ProductDetail>(entity =>
            {
                entity.HasOne(d => d.Color)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_ProductDetails_Colors");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductDetails_Products");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.SaleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductDetails_Sales");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductDetails)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ProductDetails_Sizes");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.ActionCode).HasMaxLength(50);

                entity.Property(e => e.ActionName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Start).HasColumnType("datetime");
            });

            modelBuilder.Entity<Seeding>(entity =>
            {
                entity.ToTable("Seeding");

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Suggest>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Suggests)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Suggests_Products");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasMany(d => d.Permissions)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserPermission",
                        l => l.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").HasConstraintName("FK_UserPermistion_Permision"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_UserPermistion_Users"),
                        j =>
                        {
                            j.HasKey("UserId", "PermissionId").HasName("PK_UserPermistion");

                            j.ToTable("UserPermission");
                        });
            });

            modelBuilder.Entity<WebConfig>(entity =>
            {
                entity.ToTable("WebConfig");
            });
        }
    }
}
