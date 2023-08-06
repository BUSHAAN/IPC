using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("ENMT_Types")]
    public partial class EnmtType
    {
        public EnmtType()
        {
            Constitutionals = new HashSet<Constitutional>();
        }

        [Key]
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(Constitutional.TypeCodeNavigation))]
        public virtual ICollection<Constitutional> Constitutionals { get; set; }
    }
}
