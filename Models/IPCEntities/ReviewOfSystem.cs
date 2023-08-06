using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("Review_of_System")]
    public partial class ReviewOfSystem
    {
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("code")]
        [StringLength(50)]
        public string Code { get; set; }
        [Required]
        [Column("value")]
        [StringLength(50)]
        public string Value { get; set; }
        [Required]
        [Column("note")]
        public string Note { get; set; }
        [Column("datestamp", TypeName = "datetime")]
        public DateTime Datestamp { get; set; }
        [Required]
        [Column("review_type")]
        [StringLength(50)]
        public string ReviewType { get; set; }
    }
}
