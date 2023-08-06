using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("PhysicalExam_Sub_Types")]
    public partial class PhysicalExamSubType
    {
        [Required]
        [Column("exam_type")]
        [StringLength(50)]
        public string ExamType { get; set; }
        [Key]
        [Column("subcode")]
        [StringLength(50)]
        public string Subcode { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [ForeignKey(nameof(ExamType))]
        [InverseProperty(nameof(PhysicalExamType.PhysicalExamSubTypes))]
        public virtual PhysicalExamType ExamTypeNavigation { get; set; }
    }
}
