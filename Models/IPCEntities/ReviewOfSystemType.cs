using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("ReviewOfSystem_Types")]
    public partial class ReviewOfSystemType
    {
        [Key]
        [Column("review_code")]
        [StringLength(50)]
        public string ReviewCode { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
    }
}
