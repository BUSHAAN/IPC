using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("Constitutional")]
    public partial class Constitutional
    {
        [Key]
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
        [Required]
        [Column("type_code")]
        [StringLength(50)]
        public string TypeCode { get; set; }

        [ForeignKey(nameof(TypeCode))]
        [InverseProperty(nameof(EnmtType.Constitutionals))]
        public virtual EnmtType TypeCodeNavigation { get; set; }
    }
}
