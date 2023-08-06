using IPC.Data;
using IPC.Models;
using IPC.Models.IPCEntities;
using IPC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPC.Controllers
{
    public class DoctorController : Controller
    {
        RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();
        Patient patient = new Patient();
        Vital vital = new Vital();
        private readonly IPCContext _context;
        private readonly IPatientRepository _patientRepository;

        public RedBoxLayoutViewModel createEmpty()
        {
           
            rbmodel.patient.Name = null;
            rbmodel.patient.Address = null;
            rbmodel.patient.Bloodgrp = null;
            rbmodel.patient.Dob = null;
            rbmodel.patient.District = null;
            rbmodel.patient.Email = null;
            rbmodel.patient.Gender = null;
            rbmodel.patient.Nic = null;
            rbmodel.patient.PatientId = null;
            rbmodel.patient.Occupation = null;
            rbmodel.patient.Tp = null;
            rbmodel.vital.VitalId = null;
            rbmodel.vital.AppCode = null;
            rbmodel.vital.Bloodpressure = null;
            rbmodel.vital.Weight = null;
            rbmodel.vital.Height = null;
            rbmodel.vital.Pulse = null;
            rbmodel.vital.Temp = null;
            rbmodel.vital.Po2 = null;
            rbmodel.vital.UserId = null;
            rbmodel.vital.Bmi = null;

            return rbmodel;
        }

        public DoctorController(IPatientRepository patientRepository, IPCContext context)
        {
            _context = context;
            _patientRepository = patientRepository;
        }

        public IActionResult Recieve(RedBoxLayoutViewModel model)
        {
            string[] commandSplit = model.command.Split(' ');
            if (commandSplit[0] == null)
            {
                return RedirectToAction("Recieve", "Doctor", model);
            }

            //search command
            if (commandSplit[0].ToLower() == "ser")
            {
                vital = _patientRepository.GetPatientAPC(commandSplit[1]);
                
                if (vital == null)
                {   
                    rbmodel = createEmpty();
                    return RedirectToAction("DoctorDashboard", "Doctor", rbmodel);
                }
                else {
                    var query = from Vital in _context.Vitals
                                    join Patient in _context.Patients
                                    on Vital.UserId equals Patient.PatientId
                                    where Vital.AppCode == vital.AppCode
                                    select new { 
                                        Vital.AppCode,
                                        Vital.Bloodpressure,
                                        Vital.Weight,
                                        Vital.Height,
                                        Vital.Pulse,
                                        Vital.Temp,
                                        Vital.Po2,
                                        Vital.Timestamp,
                                        Vital.Bmi,
                                        Patient.PatientId,
                                        Patient.Nic,
                                        Patient.Name,
                                        Patient.Address,
                                        Patient.Tp,
                                        Patient.Email,
                                        Patient.Dob,
                                        Patient.Gender,
                                        Patient.Bloodgrp,
                                        Patient.Occupation,
                                        Patient.District
                                    };
                    
                    foreach(var detail in query)
                    {
                        rbmodel.vital.AppCode = detail.AppCode;
                        rbmodel.vital.Bloodpressure = detail.Bloodpressure;
                        rbmodel.vital.Weight = detail.Weight;
                        rbmodel.vital.Height = detail.Height;
                        rbmodel.vital.Pulse = detail.Pulse;
                        rbmodel.vital.Temp = detail.Temp;
                        rbmodel.vital.Po2 = detail.Po2; 
                        rbmodel.vital.Timestamp = detail.Timestamp;
                        rbmodel.vital.Bmi = detail.Bmi;
                        rbmodel.patient.PatientId = detail.PatientId;
                        rbmodel.patient.Nic = detail.Nic; 
                        rbmodel.patient.Name = detail.Name; 
                        rbmodel.patient.Address = detail.Address;
                        rbmodel.patient.Tp = detail.Tp; 
                        rbmodel.patient.Email = detail.Email; 
                        rbmodel.patient.Dob = detail.Dob; 
                        rbmodel.patient.Gender = detail.Gender; 
                        rbmodel.patient.Bloodgrp = detail.Bloodgrp; 
                        rbmodel.patient.Occupation = detail.Occupation; 
                        rbmodel.patient.District = detail.District; 
                    }
                    
                return RedirectToAction("DoctorDashboard", "Doctor", rbmodel);
                }
            }
            //

            //clear command
            else if (commandSplit[0].ToLower() == "clr")
            {
                
                rbmodel = createEmpty();
                return RedirectToAction("DoctorDashboard", "Doctor", rbmodel);
            }
            //

            else
            {
                rbmodel = createEmpty();
                return RedirectToAction("DoctorDashboard", "Doctor", rbmodel);

            }
        }


        public IActionResult DoctorDashboard()
        {
            

            return View();
        }
    }
}
