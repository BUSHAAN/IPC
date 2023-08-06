using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("Medication_history")]
    public partial class MedicationHistory
    {
        [Required]
        [Column("med_code")]
        [StringLength(50)]
        public string MedCode { get; set; }
        [Column("date_ordered", TypeName = "date")]
        public DateTime DateOrdered { get; set; }
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("dose")]
        [StringLength(10)]
        public string Dose { get; set; }
        [Required]
        [Column("freq")]
        [StringLength(10)]
        public string Freq { get; set; }
        [Column("timestamp", TypeName = "date")]
        public DateTime Timestamp { get; set; }

        [ForeignKey(nameof(MedCode))]
        public virtual MedicationType MedCodeNavigation { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }
    }
}
