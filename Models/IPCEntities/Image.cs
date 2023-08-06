using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    public partial class Image
    {
        [Required]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("image_name")]
        public string ImageName { get; set; }
        [Required]
        [Column("image", TypeName = "image")]
        public byte[] Image1 { get; set; }
        [Column("datestamp", TypeName = "date")]
        public DateTime? Datestamp { get; set; }
    }
}
