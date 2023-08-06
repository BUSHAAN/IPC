using IPC.Models.IPCEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPC.Models
{
    public interface IPatientRepository
    {
        Patient GetPatient(string id);
        Vital GetPatientAPC(string id);
        Patient Add(Patient patient);

        Vital AddAPC(Vital vital);
        Patient Update(Patient patientChanges);
        Patient Delete(string id);

        Vital DelVital(string id);
        SocialHistory GetSocialHistory(string id);
        Allergies GetAllergies(string id);
    }
}
