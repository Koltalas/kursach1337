namespace WindowsFormsApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ejournal.users")]
    public partial class users
    {
        [Key]
        public int uid { get; set; }

        [Required]
        [StringLength(36)]
        public string ulogin { get; set; }

        [Required]
        [StringLength(36)]
        public string upassword { get; set; }

        [StringLength(36)]
        public string uname { get; set; }

        public bool uisteacher { get; set; }
    }
}
