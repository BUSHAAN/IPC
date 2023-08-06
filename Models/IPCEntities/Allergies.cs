using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IPC.Models.IPCEntities
{
    public class Allergies
    {
        [Key]
        [Column("Patient_id")]
        [StringLength(10)]
        public string Patient_id { get; set; }
        [Required]
        [Column("Allergy_Type")]
        [StringLength(50)]
        public string AllergyType { get; set; }
        [Required]
        [Column("IsChecked")]
        public bool IsChecked { get; set; }

    }

    public class Checkallergy
    {
        public List<Allergies> Allergies { get; set; }
    }

}

