using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("Follow_Up")]
    public partial class FollowUp
    {
        [Required]
        [Column("patient_name")]
        public string PatientName { get; set; }
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Column("app_call")]
        [StringLength(10)]
        public string AppCall { get; set; }
        [Column("foll_date", TypeName = "date")]
        public DateTime? FollDate { get; set; }
        [Column("foll_phys")]
        public string FollPhys { get; set; }
        [Column("foll_ma")]
        [StringLength(10)]
        public string FollMa { get; set; }
        [Column("foll_spec")]
        public string FollSpec { get; set; }
        [Column("foll_physio")]
        public string FollPhysio { get; set; }
        [Column("foll_diet")]
        public string FollDiet { get; set; }
        [Column("sub_lab")]
        public string SubLab { get; set; }
        [Column("datestamp", TypeName = "date")]
        public DateTime Datestamp { get; set; }
    }
}
