namespace TuRM.Portrait.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestItem
    {
        public int Id { get; set; }

        public int RequestHeadId { get; set; }

        [StringLength(64)]
        public string Name { get; set; }

        public float Amount { get; set; }

        public float Price { get; set; }

        public virtual RequestHead RequestHead { get; set; }
    }
}
