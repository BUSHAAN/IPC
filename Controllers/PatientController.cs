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
    public class PatientController : Controller
    {
        Patient patientX = new Patient();
        Patient patient = new Patient();
        private string userType;
        private readonly IPCContext _context;
        private readonly IPatientRepository _patientRepository;


        public RedBoxLayoutViewModel createEmpty()
        {
            RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();
            rbmodel.patient = new Patient();
            rbmodel.vital = new Vital();
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

        public PatientController(IPatientRepository patientRepository, IPCContext context)
        {
            _context = context;
            _patientRepository = patientRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

      




        public IActionResult MedicalAssistantDashboard(Patient patient)
        {
            RedBoxLayoutViewModel passedPatient = new RedBoxLayoutViewModel();
            passedPatient.patient = patient;
            return View(passedPatient);
        }

        public IActionResult MedicalAssistantDashboard_O(Patient patient)
        {
            RedBoxLayoutViewModel passedPatient = new RedBoxLayoutViewModel();
            passedPatient.patient = patient;
            return View(passedPatient);
        }
    }
}
