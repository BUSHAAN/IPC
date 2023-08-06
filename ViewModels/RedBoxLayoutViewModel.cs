using IPC.Models.IPCEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPC.ViewModels
{
    public class RedBoxLayoutViewModel
    {
       
        public string command { get; set; }
        public Patient patient { get; set; }
        public Vital vital { get; set; }
        public MedicalHistory medicalHistory { get; set; }
        public SocialHistory social { get; set; }
        public Allergies allergy { get; set; }
        public Checkallergy check { get; set; }

        public RedBoxLayoutViewModel( RedBoxLayoutViewModel rbmodel)
        {
            this.command = rbmodel.command;
            this.patient = rbmodel.patient;
            this.vital = rbmodel.vital;
            this.medicalHistory = rbmodel.medicalHistory;
            this.social = rbmodel.social;
            this.allergy = rbmodel.allergy;
            this.check = rbmodel.check;
        }
        public RedBoxLayoutViewModel()
        {

        }
    }


}
