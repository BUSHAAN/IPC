using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("PresentIllness")]
    public partial class PresentIllness
    {
        [Required]
        [Column("patient_id")]
        public string PatientId { get; set; }
        [Required]
        [Column("app_code")]
        public string AppCode { get; set; }
        [Required]
        [Column("symptom")]
        public string Symptom { get; set; }
        [Required]
        [Column("note")]
        public string Note { get; set; }
        [Column("datestamp", TypeName = "datetime")]
        public DateTime Datestamp { get; set; }
    }
}
