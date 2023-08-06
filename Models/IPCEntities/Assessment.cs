using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("Assessment")]
    public partial class Assessment
    {
        [Required]
        [Column("ap_code")]
        [StringLength(50)]
        public string ApCode { get; set; }
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("findings")]
        public string Findings { get; set; }
        [Required]
        [Column("plans")]
        public string Plans { get; set; }
        [Column("datestamp", TypeName = "date")]
        public DateTime Datestamp { get; set; }
    }
}
