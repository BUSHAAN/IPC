using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("Appointment")]
    public partial class Appointment
    {
        [Key]
        [Column("app_code")]
        [StringLength(50)]
        public string AppCode { get; set; }
        [Required]
        [Column("MRN")]
        [StringLength(50)]
        public string Mrn { get; set; }
        [Column("date_of_reg", TypeName = "date")]
        public DateTime DateOfReg { get; set; }
        [Column("app_date", TypeName = "date")]
        public DateTime AppDate { get; set; }
        [Required]
        [Column("doc_id")]
        [StringLength(50)]
        public string DocId { get; set; }
        [Required]
        [Column("hosp_id")]
        [StringLength(50)]
        public string HospId { get; set; }
        [Column("app_time_start")]
        public TimeSpan AppTimeStart { get; set; }
        [Column("app_end_time")]
        public TimeSpan AppEndTime { get; set; }
    }
}
