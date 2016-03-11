using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TuRM.Portrait.Models
{
    public partial class ApplicationDbContext : IApplicationDbContext
    {
        IQueryable<ProductCategory> IApplicationDbContext.ProductCategories
        {
            get { return ProductCategories; }
        }

        public ApplicationDbContext()
            :this("name=DefaultConnection")
        {

        }

        public async Task LoadCollectionAsync<TEntity, TElement>(TEntity entity, Expression<Func<TEntity, ICollection<TElement>>> navigationProperty) where TEntity : class
                                                                                                                                                      where TElement : class
        {
            //public DbCollectionEntry<TEntity, TElement> Collection<TElement>(
              //Expression<Func<TEntity, ICollection<TElement>>> navigationProperty
            //) where TElement : class;
            await Entry(entity).Collection(navigationProperty).LoadAsync();
        }
    }
}