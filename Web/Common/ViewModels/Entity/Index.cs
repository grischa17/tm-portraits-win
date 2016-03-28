using System.Collections;
using System.Linq;
using System.Reflection;

namespace TuRM.Common.ViewModels.Entity
{
    public class Index
    {
        public string Name { get; set; }

        public IQueryable<PropertyInfo> Collumns { get; set; }

        public IEnumerable Rows { get; set; }
    }
}