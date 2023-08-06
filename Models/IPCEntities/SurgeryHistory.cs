using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("Surgery_history")]
    public partial class SurgeryHistory
    {
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("surgical_code")]
        [StringLength(50)]
        public string SurgicalCode { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [Column("hospital_id")]
        [StringLength(50)]
        public string HospitalId { get; set; }
        [Required]
        [Column("doc_id")]
        [StringLength(50)]
        public string DocId { get; set; }
        [Column("timestamp", TypeName = "date")]
        public DateTime Timestamp { get; set; }

        [ForeignKey(nameof(DocId))]
        public virtual Doctor Doc { get; set; }
        [ForeignKey(nameof(HospitalId))]
        public virtual Hospital Hospital { get; set; }
        [ForeignKey(nameof(PatientId))]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(SurgicalCode))]
        public virtual Surgery SurgicalCodeNavigation { get; set; }
    }
}
