using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Keyless]
    [Table("DrugsList")]
    public partial class DrugsList
    {
        [Column("Generic_Name ")]
        [StringLength(255)]
        public string GenericName { get; set; }
        [Column("Brand_Name ")]
        [StringLength(255)]
        public string BrandName { get; set; }
        [Column("Purpose ")]
        [StringLength(255)]
        public string Purpose { get; set; }
    }
}
