using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("Lab_Reports")]
    public partial class LabReport
    {
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("Lab_Name")]
        public string LabName { get; set; }
        [Required]
        [Column("Content_Type")]
        public string ContentType { get; set; }
        [Required]
        [Column("Lab_Report")]
        public byte[] LabReport1 { get; set; }
        [Column("datestamp", TypeName = "date")]
        public DateTime Datestamp { get; set; }
    }
}
