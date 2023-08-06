using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("PhysicalExam_Types")]
    public partial class PhysicalExamType
    {
        public PhysicalExamType()
        {
            PhysicalExamSubType1s = new HashSet<PhysicalExamSubType1>();
            PhysicalExamSubTypes = new HashSet<PhysicalExamSubType>();
        }

        [Key]
        [Column("exam_types")]
        [StringLength(50)]
        public string ExamTypes { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(PhysicalExamSubType1.ExamTypeNavigation))]
        public virtual ICollection<PhysicalExamSubType1> PhysicalExamSubType1s { get; set; }
        [InverseProperty(nameof(PhysicalExamSubType.ExamTypeNavigation))]
        public virtual ICollection<PhysicalExamSubType> PhysicalExamSubTypes { get; set; }
    }
}
