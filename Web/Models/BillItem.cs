namespace TuRM.Portrait.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillItem
    {
        public int Id { get; set; }

        public int HeadId { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public int RequestItemId { get; set; }

        public float Amount { get; set; }

        public float Price { get; set; }

        public virtual BillHead BillHead { get; set; }
    }
}
