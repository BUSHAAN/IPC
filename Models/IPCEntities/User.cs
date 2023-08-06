using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    public partial class User
    {
        [Required]
        [Remote(action: "IsUserValid",controller:"Account")]
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [Column("pw")]
        [StringLength(50)]
        public string Pw { get; set; }
        [Required]
        [Column("category")]
        [StringLength(50)]
        public string Category { get; set; }
    }
}
