using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("PhysicalExam_SubTypes")]
    public partial class PhysicalExamSubType1
    {
        public PhysicalExamSubType1()
        {
            PhysicalExamSubLevelTypes = new HashSet<PhysicalExamSubLevelType>();
        }

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
        [InverseProperty(nameof(PhysicalExamType.PhysicalExamSubType1s))]
        public virtual PhysicalExamType ExamTypeNavigation { get; set; }
        [InverseProperty(nameof(PhysicalExamSubLevelType.CodeNavigation))]
        public virtual ICollection<PhysicalExamSubLevelType> PhysicalExamSubLevelTypes { get; set; }
    }
}
