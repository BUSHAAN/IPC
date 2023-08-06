using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IPC.Models.IPCEntities
{
    [Table("SocialHistory")]
    public partial class SocialHistory
    {
		[Key]
		[Column("patient_id")]
		public string patientID { get; set; }

		[Column("marital_status")]
		[StringLength(50)]
		public string Marital_Status { get; set; }

		[Column("smoking")]
		[StringLength(50)]
		public string Smoking { get; set; }

		[Column("smoking_years")]
		[StringLength(50)]
		public string Smoking_years { get; set; }

		[Column("drugs")]
		[StringLength(50)]
		public string Drugs { get; set; }

		[Column("alcohol")]
		[StringLength(50)]
		public string Alcohol { get; set; }

		[Column("alco_freq")]
		[StringLength(50)]
		public string Alco_freq { get; set; }

	}
}
