using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    public partial class RosType
    {
        [Required]
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
