using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuRM.Portrait.Models
{
    public class ApplicationDbContextInitializier : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected async override void Seed(ApplicationDbContext context)
        {
            Product bleistift, buntstift, pastel, a2, a3, a4, countPersonsProduct;
            ProductCategory portrait, sizes, countPersonsCategory;
            PriceAdjustment countPersonPriceAdjustment;

            portrait = new ProductCategory();
            portrait.Name = "Porträt";

            context.ProductCategories.Add(portrait);
            await context.SaveChangesAsync();
            await context.Entry(portrait).ReloadAsync();
            
            bleistift = new Product();
            bleistift.Name = "Bleistiftporträt";
            bleistift.Price = 60.0f;
            bleistift.ProductCategoryId = portrait.Id;
            context.Products.Add(bleistift);

            buntstift = new Product();
            buntstift.Name = "Buntstiftporträt";
            buntstift.Price = 80.0f;
            buntstift.ProductCategoryId = portrait.Id;
            context.Products.Add(buntstift);

            pastel = new Product();
            pastel.Name = "Pastelporträt";
            pastel.Price = 100.0f;
            pastel.ProductCategoryId = portrait.Id;
            context.Products.Add(pastel);

            sizes = new ProductCategory();
            sizes.Name = "Größen";
            context.ProductCategories.Add(sizes);

            await context.SaveChangesAsync();
            await context.Entry(sizes).ReloadAsync();

            a4 = new Product();
            a4.Name = "A4";
            a4.Price = 0.0f;
            a4.ProductCategoryId = sizes.Id;
            context.Products.Add(a4);

            a3 = new Product();
            a3.Name = "A3";
            a3.Price = 30.0f;
            a3.ProductCategoryId = sizes.Id;
            context.Products.Add(a3);

            a2 = new Product();
            a2.Name = "A2";
            a2.Price = 60.0f;
            a2.ProductCategoryId = sizes.Id;
            context.Products.Add(a2);
            
            countPersonsCategory = new ProductCategory();
            countPersonsCategory.Name = "Anzahl Personen";
            context.ProductCategories.Add(countPersonsCategory);

            await context.SaveChangesAsync();
            await context.Entry(sizes).ReloadAsync();

            countPersonsProduct = new Product();
            countPersonsProduct.Name = "Anzahl Personen";
            countPersonsProduct.Price = 20.0f;
            countPersonsProduct.ProductCategoryId = countPersonsCategory.Id;
            
            context.Products.Add(countPersonsProduct);
            await context.SaveChangesAsync();

            countPersonPriceAdjustment = new PriceAdjustment();
            countPersonPriceAdjustment.Name = "Erste Person inklusive";
            countPersonPriceAdjustment.Adjustment = -20.0f;
            countPersonPriceAdjustment.Products.Add(countPersonsProduct);

            context.PriceAdjustments.Add(countPersonPriceAdjustment);
            await context.SaveChangesAsync();

            base.Seed(context);
        }
    }
}
