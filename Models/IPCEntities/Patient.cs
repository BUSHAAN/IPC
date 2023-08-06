using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("Patient")]
    public partial class Patient
    {
        [Key][Required(ErrorMessage = "this field is required")]
        [Column("patient_id")]
        [StringLength(50)]
        public string PatientId { get; set; }
        [Required]
        [Column("NIC")]
        [StringLength(10)]
        public string Nic { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("TP")]
        [StringLength(10)]
        public string Tp { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage = "Invalid Email Address")]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("dob")]
        [StringLength(50)]
        public string Dob { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("bloodgrp")]
        [StringLength(10)]
        public string Bloodgrp { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("occupation")]
        [StringLength(50)]
        public string Occupation { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [Column("district")]
        [StringLength(50)]
        public string District { get; set; }
    }
}
