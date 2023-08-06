using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("Hospital")]
    public partial class Hospital
    {
        [Key]
        [Column("hospital_id")]
        [StringLength(50)]
        public string HospitalId { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("TP")]
        [StringLength(10)]
        public string Tp { get; set; }
    }
}
