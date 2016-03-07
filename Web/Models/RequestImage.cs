namespace TuRM.Portrait.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequestImage
    {
        public int Id { get; set; }

        public int RequestHeadId { get; set; }

        public byte[] Data { get; set; }

        public virtual RequestHead RequestHead { get; set; }
    }
}
