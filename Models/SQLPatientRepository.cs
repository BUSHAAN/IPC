using IPC.Data;
using IPC.Models.IPCEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPC.ViewModels;

namespace IPC.Models
{
    public class SQLPatientRepository : IPatientRepository
    {
        private readonly IPCContext context;

        public SQLPatientRepository(IPCContext context)
        {
            this.context = context;
        }
        public Patient Add(Patient patient)
        {
            context.Patients.Add(patient);
            context.SaveChanges();
            return patient;
        }

        public Vital AddAPC(Vital vital)
        {
            DateTime now = DateTime.Now;
            vital.Timestamp = now;
            context.Vitals.Add(vital);
            context.SaveChanges();
            return vital;
        }

        public Patient Delete(string id)
        {
            Patient patient = context.Patients.Find(id);
            if(patient != null)
            {
                context.Patients.Remove(patient);
                context.SaveChanges();
            }
            return patient;
        }

        public Vital DelVital(string id)
        {
            Vital vital = context.Vitals.Find(id);
            if (vital != null)
            {
                context.Vitals.Remove(vital);
                context.SaveChanges();
            }
            return vital;
        }

        public Patient GetPatient(string id)
        {
            Patient patient = context.Patients.Find(id);
            return patient;
        }

        public Vital GetPatientAPC(string appcode)
        {
            Vital vital = context.Vitals.Where(x => x.AppCode == appcode).FirstOrDefault();
            return vital;
        }

        public SocialHistory GetSocialHistory(string id)
        {
            SocialHistory socialhistory = context.SocialHistories.Find(id);
            return socialhistory;
        }

        public Allergies GetAllergies(string id)
        {
            Allergies allergies = context.Allergies.Find(id);
            return allergies;
        }

        public Patient Update(Patient patientChanges)
        {
            var patient = context.Patients.Attach(patientChanges);
            patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return patientChanges;
        }
    }
}
