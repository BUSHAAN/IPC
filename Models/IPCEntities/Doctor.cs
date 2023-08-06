using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("Doctor")]
    public partial class Doctor
    {
        [Key]
        [Column("doc_Id")]
        [StringLength(50)]
        public string DocId { get; set; }
        [Required]
        [Column("NIC")]
        [StringLength(10)]
        public string Nic { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column("speciality_code")]
        [StringLength(10)]
        public string SpecialityCode { get; set; }
        [Column("joint_date", TypeName = "date")]
        public DateTime JointDate { get; set; }
        [Required]
        [Column("TP")]
        [StringLength(10)]
        public string Tp { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }

        [ForeignKey(nameof(SpecialityCode))]
        [InverseProperty(nameof(Specialization.Doctors))]
        public virtual Specialization SpecialityCodeNavigation { get; set; }
    }
}
