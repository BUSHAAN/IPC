using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    public partial class Referral
    {
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("speciality")]
        [StringLength(50)]
        public string Speciality { get; set; }
        [Required]
        [Column("doc_name")]
        [StringLength(50)]
        public string DocName { get; set; }
        [Column("datestamp", TypeName = "datetime")]
        public DateTime Datestamp { get; set; }
    }
}
