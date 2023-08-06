using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("Allergy_Types")]
    public partial class AllergyType
    {
        [Key]
        [Column("allergy_code")]
        [StringLength(10)]
        public string AllergyCode { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
