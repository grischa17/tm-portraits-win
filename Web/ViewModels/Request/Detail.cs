using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TuRM.Portrait.ViewModels.Request
{
    public class Detail
    {
        public Head Head { get; set; }

        public List<Item> Items { get; set; }

        //public Product Product { get; set; }

        //[Display(Name = "Produkt:")]
        //public Item ProductItem { get; set; }

        //public Product Size { get; set; }

        //public Item SizeItem { get; set; }

        //[Display(Name = "Anzahl Subjekte")]
        //public Item SubjectItem { get; set; }

        //public Product SubjectProduct { get; set; }

        public List<Image> Images { get; set; }
    }
}
