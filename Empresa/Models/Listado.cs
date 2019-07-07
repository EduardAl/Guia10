namespace Guia10_RB140362.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Listado")]
    public partial class Listado
    {
        [Key]
        public int codigo { get; set; }

        [Required]
        [StringLength(80)]
        public string nombre { get; set; }

        [Required]
        [StringLength(80)]
        public string apellido { get; set; }
    }
}
