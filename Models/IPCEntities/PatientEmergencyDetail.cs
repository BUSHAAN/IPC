using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    public partial class PatientEmergencyDetail
    {
        [Key]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("primary_physician")]
        [StringLength(50)]
        public string PrimaryPhysician { get; set; }
        [Required]
        [Column("pharmacy_fax_num")]
        [StringLength(50)]
        public string PharmacyFaxNum { get; set; }
        [Required]
        [Column("emergency_contact")]
        [StringLength(50)]
        public string EmergencyContact { get; set; }
    }
}
