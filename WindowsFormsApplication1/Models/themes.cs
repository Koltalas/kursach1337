namespace WindowsFormsApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ejournal.themes")]
    public partial class themes
    {
        [Key]
        public int tid { get; set; }

        [Required]
        [StringLength(255)]
        public string tname { get; set; }
    }
}
