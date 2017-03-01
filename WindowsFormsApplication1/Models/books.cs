namespace WindowsFormsApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ejournal.books")]
    public partial class books
    {
        [Key]
        public int bid { get; set; }

        public int tid { get; set; }

        [Required]
        [StringLength(36)]
        public string bname { get; set; }

        [Column(TypeName = "blob")]
        public byte[] document { get; set; }
    }
}
