using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("Specialization")]
    public partial class Specialization
    {
        public Specialization()
        {
            Doctors = new HashSet<Doctor>();
        }

        [Key]
        [Column("speciality_code")]
        [StringLength(10)]
        public string SpecialityCode { get; set; }
        [Required]
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty(nameof(Doctor.SpecialityCodeNavigation))]
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
