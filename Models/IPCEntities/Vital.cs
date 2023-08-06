using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    public partial class Vital
    {
        [Key][Required(ErrorMessage = "this field is required")]
        [Column("vital_id")]
        [StringLength(50)]
        public string VitalId { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("app_code")]
        [StringLength(50)]
        public string AppCode { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("bloodpressure")]
        [StringLength(10)]
        public string Bloodpressure { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("weight")]
        [StringLength(10)]
        public string Weight { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("height")]
        [StringLength(10)]
        public string Height { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("pulse")]
        [StringLength(10)]
        public string Pulse { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("temp")]
        [StringLength(10)]
        public string Temp { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("po2")]
        [StringLength(10)]
        public string Po2 { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("user_id")]
        [StringLength(50)]
        public string UserId { get; set; }
        [Column("timestamp", TypeName = "datetime")]
        public DateTime Timestamp { get; set; }
        
        [Column("BMI")]
        [StringLength(50)]
        public string Bmi { get; set; }
    }
}
