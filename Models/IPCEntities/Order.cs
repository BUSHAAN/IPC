using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    public partial class Order
    {
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Required]
        [Column("dosage")]
        [StringLength(50)]
        public string Dosage { get; set; }
        [Column("datestamp", TypeName = "datetime")]
        public DateTime Datestamp { get; set; }
    }
}
