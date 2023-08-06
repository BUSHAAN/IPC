using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("Doctor_Works_for")]
    public partial class DoctorWorksFor
    {
        [Required]
        [Column("doc_id")]
        [StringLength(50)]
        public string DocId { get; set; }
        [Required]
        [Column("hosp_id")]
        [StringLength(50)]
        public string HospId { get; set; }
        [Column("join_date", TypeName = "date")]
        public DateTime JoinDate { get; set; }
    }
}
