using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("PhysicalExam_Sub_Level_Types")]
    public partial class PhysicalExamSubLevelType
    {
        [Key]
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; }
        [Key]
        [Column("subcode")]
        [StringLength(50)]
        public string Subcode { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [ForeignKey(nameof(Code))]
        [InverseProperty(nameof(PhysicalExamSubType1.PhysicalExamSubLevelTypes))]
        public virtual PhysicalExamSubType1 CodeNavigation { get; set; }
    }
}
