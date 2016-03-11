using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TuRM.Portrait.Models
{
    public interface IApplicationDbContext
    {
        DbSet<BillCancellation> BillCancellations { get; set; }
        DbSet<BillHead> BillHeads { get; set; }
        DbSet<BillItem> BillItems { get; set; }
        DbSet<PriceAdjustment> PriceAdjustments { get; set; }
        IQueryable<ProductCategory> ProductCategories { get; }
        DbSet<Product> Products { get; set; }
        DbSet<RequestCancellation> RequestCancellations { get; set; }
        DbSet<RequestHead> RequestHeads { get; set; }
        DbSet<RequestImage> RequestImages { get; set; }
        DbSet<RequestItem> RequestItems { get; set; }
        
        Task LoadCollectionAsync<TEntity, TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> navigationProperty) where TEntity : class
                                                                                                                                         where TElement : class;
    }
}