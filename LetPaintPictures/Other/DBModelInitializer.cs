namespace LetPaintPictures.Other
{
    using Models;
    using System.Collections.Generic;
    using System.Data.Entity;


    public class DBModelInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            Product subjectProduct = new Product() { Name = "Person oder Subjekt", Price = 20f, ProductCategoryId = 3 };
            PriceAdjustment subjectPriceAdjustment = new PriceAdjustment() { Name = "Erste Person oder Subjekt inkl.", Adjustment = -subjectProduct.Price };

            base.Seed(context);

            context.ProductCategories.Add(new ProductCategory() { Name = "Portrait" });
            context.ProductCategories.Add(new ProductCategory() { Name = "Größe" });
            context.ProductCategories.Add(new ProductCategory() { Name = "Person oder Subjekt" });

            context.SaveChanges();

            context.Products.Add(new Product() { Name = "Bleistift-Portrait", Price = 60f, ProductCategoryId = 1 });
            context.Products.Add(new Product() { Name = "Buntstift-Portrait", Price = 80f, ProductCategoryId = 1 });

            context.Products.Add(new Product() { Name = "A4", ProductCategoryId = 2 });
            context.Products.Add(new Product() { Name = "A3", Price = 30f, ProductCategoryId = 2 });
            context.Products.Add(new Product() { Name = "A2", Price = 60f, ProductCategoryId = 2 });

            context.Products.Add(subjectProduct);

            context.PriceAdjustments.Add(subjectPriceAdjustment);

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('" + nameof(context.BillHeads) + "', RESEED, 2)");

            context.SaveChanges();

            context.Entry<Product>(subjectProduct).Reload();
            context.Entry<PriceAdjustment>(subjectPriceAdjustment).Reload();

            subjectProduct.PriceAdjustments = subjectProduct.PriceAdjustments ?? new List<PriceAdjustment>();
            subjectProduct.PriceAdjustments.Add(subjectPriceAdjustment);

            context.SaveChanges();

        }
    }
    
}