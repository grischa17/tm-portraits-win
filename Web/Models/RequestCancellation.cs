namespace TuRM.Portrait.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestCancellation
    {
        public int Id { get; set; }

        public int RequestHeadId { get; set; }

        [Required]
        [StringLength(256)]
        public string Reason { get; set; }

        public virtual RequestHead RequestHead { get; set; }
    }
}
