using IPC.Data;
using IPC.Models;
using IPC.Models.IPCEntities;
using IPC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace IPC.Controllers
{
    public class AccountController : Controller
    {
        static string editPatientId = "";
        RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();
        Patient patientX = new Patient();
        Vital vital = new Vital();
        SocialHistory socialhistory = new SocialHistory();
        Allergies allergies = new Allergies();
        Checkallergy check = new Checkallergy();
        static string userType = "";
        static string userIdentification = "";//*****
        static bool addApcFlag = false;
        private readonly IPatientRepository _patientRepository;
        
        private IPCContext context { get; }
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IPCContext context, IPatientRepository patientRepository)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._patientRepository = patientRepository;
        }




        public RedBoxLayoutViewModel createEmpty()
        {
            RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();
            rbmodel.patient = new Patient();
            rbmodel.vital = new Vital();
            rbmodel.social = new SocialHistory();
            rbmodel.allergy = new Allergies();
            rbmodel.check = new Checkallergy();
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
            rbmodel.social.patientID = null;
            rbmodel.social.Marital_Status = null;
            rbmodel.social.Smoking = null;
            rbmodel.social.Smoking_years = null;
            rbmodel.social.Drugs = null;
            rbmodel.social.Alcohol = null;
            rbmodel.social.Alco_freq = null;
            rbmodel.allergy.Patient_id = null;
            rbmodel.allergy.AllergyType = null;
            rbmodel.allergy.IsChecked = false; 
            rbmodel.check.Allergies = null;

            return rbmodel;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(LoginViewModel model)
        {
            User user = new User() ;
            if (ModelState.IsValid) { 
                  user = context.Users.FirstOrDefault(x => x.Username == model.Username);
            }
            else
            {
                return View("Login"); 
            }
            if (user != null)
                {
                    if (user.Pw == model.Password)
                    {
                    RedBoxLayoutViewModel blankpatient = createEmpty();
                    userType = user.Category;
                    if (user.Category == "Doctor")
                        {
                        
                            return View("DoctorDashboard", blankpatient);
                        }
                        if (user.Category == "MA")
                        {

                            return View("MedicalAssistantDashboard" , blankpatient);
                        }
                        if (user.Category == "Clerk")
                        {

                        return View("ClerkDashboard", blankpatient);
                        
                        }
                    }
                }
            ViewBag.Message = String.Format("Incorrect Credentials!");
            return View("Login");                     
        }

        [AcceptVerbs("Get","Post")]
        public IActionResult IsUserValid(string username)
        {
            User user = context.Users.Find(username);
            if (user != null)
            {
                return Json(true);
            }
            else
            {
                return Json($"invalid Username");
            }
        }
        
        public IActionResult Recieve(RedBoxLayoutViewModel model)
        {
            string[] commandSplit = { "", "", "", "", "" };
            
            if (model.command != null)
            {
                commandSplit = model.command.Split(' ');
            }
            if (commandSplit[0] == null)
            {
                RedBoxLayoutViewModel _patient = createEmpty();
                return View("MedicalAssistantDashboard", _patient);
            }

            //search clerk
            else if (commandSplit[0].ToLower() == "ser" && userType == "Clerk" )
            {
                RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();

                patientX = _patientRepository.GetPatient(commandSplit[1]);
                if (patientX == null)
                {
                    RedBoxLayoutViewModel _patient = createEmpty();
                    ViewBag.Message = String.Format("Patient Not Found!");
                    return View("ClerkDashboard", _patient);
                }
                rbmodel.patient = patientX;
                userIdentification = patientX.PatientId;
                return View("ClerkDashboard", rbmodel);
            }
            //

            //search MA
            else if (commandSplit[0].ToLower() == "ser" && userType == "MA")
            {
                RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();
                if (commandSplit[1] == "" || commandSplit[1] == null)
                {
                    RedBoxLayoutViewModel _patient = createEmpty();
                    return View("MedicalAssistantDashboard", _patient);
                }
                else
                {
                    patientX = _patientRepository.GetPatient(commandSplit[1]);
                    if (patientX == null)
                    {
                        RedBoxLayoutViewModel _patient = createEmpty();
                      
                        ViewBag.Message = String.Format("Patient Not Found!");
                        return View("MedicalAssistantDashboard", _patient);
                    }
                    rbmodel.vital = new Vital();
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
                    rbmodel.patient = patientX;
                    userIdentification = patientX.PatientId;
                    return View("MedicalAssistantDashboard", rbmodel);
                }
            }
            //

            //search APC MA
            else if (commandSplit[0].ToLower() == "serapc" && userType == "MA")
            {

                vital = _patientRepository.GetPatientAPC(commandSplit[1]);
                if (vital != null)
                {
                    patientX = _patientRepository.GetPatient(vital.UserId);
                }
                


                if (vital == null || patientX == null)
                {
                    rbmodel = createEmpty();
                    ViewBag.Message = String.Format("Vitals Not Found!");
                    return View("MedicalAssistantDashboard", rbmodel);
                }

                else
                {
                    rbmodel = createEmpty();
                    rbmodel.vital = vital;
                    rbmodel.patient = patientX;
                    userIdentification = patientX.PatientId;
                    return View("MedicalAssistantDashboard", rbmodel);
                }
            }
            //

            //search socialhistory
            else if (commandSplit[0].ToLower() == "sh" && (userType == "MA" || userType == "Doctor"))
            {
                RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();
                if (commandSplit[1] == "" || commandSplit[1] == null)
                {
                    RedBoxLayoutViewModel shmodel = createEmpty();
                    return View("SocialHistory", shmodel);
                }

                else
                {
                    socialhistory = _patientRepository.GetSocialHistory(commandSplit[1]);
                    if (socialhistory.patientID == null)
                    {
                        RedBoxLayoutViewModel shmodel = createEmpty();
                        return View("SocialHistory", shmodel);
                    }
                    rbmodel.social = socialhistory;
                    userIdentification = socialhistory.patientID;
                    return View("SocialHistory", rbmodel);

                }
            }
            //

            //search Allergies
            else if (commandSplit[0].ToLower() == "all" && (userType == "MA" || userType == "Doctor"))
            {
                RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();
                if (commandSplit[1] == "" || commandSplit[1] == null)
                {
                    RedBoxLayoutViewModel allmodel = createEmpty();
                    return View("Allergies", allmodel);
                }

                else
                {
                    allergies = _patientRepository.GetAllergies(commandSplit[1]);
                    List<Allergies> check2 = new List<Allergies>()
                    {
                       new Allergies {Patient_id="1", AllergyType="Penicillin",IsChecked=true},
                        new Allergies {Patient_id="1", AllergyType="Betedine",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Sulpha",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Demerol",IsChecked=true},
                        new Allergies {Patient_id="1", AllergyType="Morphine",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Latex",IsChecked=true},
                        new Allergies {Patient_id="1", AllergyType="Tetracycline",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Codeine",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Cipro",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Contrast Dye",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Food",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Medicine",IsChecked=false},
                        new Allergies {Patient_id="1", AllergyType="Other",IsChecked=false},

                    };
                    if (allergies.Patient_id == null)
                    {
                        RedBoxLayoutViewModel allmodel = createEmpty();
                        return View("Allergies", allmodel);
                    }
                    check.Allergies = check2;
                    rbmodel.check = check;
                    rbmodel.allergy = allergies;
                    userIdentification = allergies.Patient_id;
                    return View("Allergies", rbmodel);

                }
            }
            //


            //search DOCTOR
            else if (commandSplit[0].ToLower() == "ser" && userType == "Doctor")
            {
                
                vital = _patientRepository.GetPatientAPC(commandSplit[1]);
                if (vital != null)
                {
                    patientX = _patientRepository.GetPatient(vital.UserId);
                }

                if (vital == null || patientX == null)
                {
                    rbmodel = createEmpty();
                    ViewBag.Message = String.Format("Vitals Not Found!");
                    return View("DoctorDashboard", rbmodel);
                }

                else
                {
                    
                    rbmodel.vital = vital;
                    rbmodel.patient = patientX;
                    userIdentification = patientX.PatientId;
                    return View("DoctorDashboard", rbmodel);
                }
            }
            //

            //clear clerk
            else if (commandSplit[0].ToLower() == "clr" && userType == "Clerk")
            {
                userIdentification = null;
                RedBoxLayoutViewModel patient = createEmpty();
                return View("ClerkDashboard", patient);
            }
            //

            //clear MA
            else if (commandSplit[0].ToLower() == "clr" && userType == "MA")
            {
                userIdentification = null;
                RedBoxLayoutViewModel patient = createEmpty();
                return View("MedicalAssistantDashboard" , patient);
            }
            //

            //clear Doctor
            else if (commandSplit[0].ToLower() == "clr" && userType == "Doctor")
            {
                userIdentification = null;
                RedBoxLayoutViewModel patient = createEmpty();
                return View("DoctorDashboard", patient);
            }
            //


            // LOGOUT
            else if (commandSplit[0].ToLower() == "logout")
            {
                userType = "";
                return View("Login");
            }
            //

            // NEW Patient
            else if (commandSplit[0].ToLower() == "new" && userType == "Clerk")
            {
                return RedirectToAction("AddNewPatient");
            }

            //

            // NEW appointment
            else if (commandSplit[0].ToLower() == "new" && userType == "MA")
            {
                return RedirectToAction("AddApcode");
            }

            // Edit Patient
            else if (commandSplit[0].ToLower() == "edit" && userType == "Clerk" && commandSplit[1].ToLower() != "")
            {
                editPatientId = commandSplit[1];
               
                Patient patientavailable = _patientRepository.GetPatient(editPatientId);
                if (patientavailable != null) {
                    rbmodel.patient = patientavailable;
                    return View("EditPatient", rbmodel);
                }
                else
                {
                    ViewBag.Message = String.Format("Patient doesnt exist");
                    rbmodel = createEmpty();
                }
                return View("ClerkDashboard", rbmodel);
            }
            //

            // DEL Patient
            else if (commandSplit[0].ToLower() == "del" && userType == "Clerk")
            {
                
                Patient deletedPatient = _patientRepository.Delete(commandSplit[1]);
                rbmodel.patient = deletedPatient;
                
                    return View("ClerkDashboard", rbmodel);
                
            }

            // DEL Vital
            else if (commandSplit[0].ToLower() == "del" && userType == "MA")
            {

                Vital deletedVital = _patientRepository.DelVital(commandSplit[1]);
                Patient patient1 = _patientRepository.GetPatient(deletedVital.UserId);
                rbmodel.patient = patient1;
                rbmodel.vital = deletedVital;
                 return View("MedicalAssistantDashboard", rbmodel);
                
            }

            //for a blank enter key
            else
            {
                ViewBag.Message = String.Format("invalid command!");
                if (userType == "Clerk")
                {
                    RedBoxLayoutViewModel patient = createEmpty();
                    return View("ClerkDashboard", patient);
                }
                else if (userType == "MA")
                {
                    RedBoxLayoutViewModel patient = createEmpty();
                    return View("MedicalAssistantDashboard", patient);
                }
                else 
                {
                    RedBoxLayoutViewModel patient = createEmpty();
                    return View("DoctorDashboard", patient);
                }
            }
        }



        [HttpGet]
        public IActionResult AddNewPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewPatient(RedBoxLayoutViewModel model)
        {
            string[] commandSplit = new string[5];
            if (model.command != null)
            {
                commandSplit = model.command.Split(' ');
            }
            else
            {
                return View();
            }
            if (commandSplit[0].ToLower() == "add")
            {
                if (ModelState.IsValid)
                {
                    Patient patientavailable = _patientRepository.GetPatient(model.patient.PatientId);
                    if (patientavailable == null)
                    {
                        Patient newPatient = _patientRepository.Add(model.patient);
                        rbmodel.patient = newPatient;
                    }
                    else
                    {
                        ViewBag.Message = String.Format("PatientID already exists!");
                        rbmodel = createEmpty();
                    }
                }
                else
                {
                    return View();
                }
                    return View("ClerkDashboard", rbmodel);
                
              
            }
            
            else if (commandSplit[0].ToLower() == "back" && userType == "Clerk")
            {
                RedBoxLayoutViewModel patient = createEmpty();
                return View("ClerkDashboard", patient);
            }
            else if (commandSplit[0].ToLower() == "logout")
            {
                userType = "";
                return View("Login");
            }
            return View();
        }



        [HttpGet]
        public IActionResult EditPatient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditPatient(RedBoxLayoutViewModel model)
        {
            string[] commandSplit = new string[5];
            if (model.command != null)
            {
                commandSplit = model.command.Split(' ');
            }
            else
            {
                return View();
            }
            if (commandSplit[0].ToLower() == "edit")
            {
                if (ModelState.IsValid)
                {
                  Patient newPatient = _patientRepository.Update(model.patient);
                  rbmodel.patient = newPatient; 
                    
                }
                else
                {
                    return View();
                }
                return View("ClerkDashboard", rbmodel);
                /*
                  RedBoxLayoutViewModel rbmodel = new RedBoxLayoutViewModel();

                patientX = _patientRepository.GetPatient();
                if (patientX == null)
                {
                    RedBoxLayoutViewModel _patient = createEmpty();
                    ViewBag.Message = String.Format("Patient Not Found!");
                    return View("ClerkDashboard", _patient);
                }
                rbmodel.patient = patientX;
                userIdentification = patientX.PatientId;
                return View("ClerkDashboard", rbmodel);
                 */

            }

            else if (commandSplit[0].ToLower() == "back" && userType == "Clerk")
            {
                RedBoxLayoutViewModel patient = createEmpty();
                return View("ClerkDashboard", patient);
            }
            else if (commandSplit[0].ToLower() == "logout")
            {
                userType = "";
                return View("Login");
            }
            return View();
        }




        [HttpGet]
        public IActionResult AddApcode()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddApcode(RedBoxLayoutViewModel model)
        {
            string[] commandSplit = new string[5];
            if (model.command != null)
            {
                commandSplit = model.command.Split(' ');
            }
            else
            {
                return View();
            }
            if (commandSplit[0].ToLower() == "add")
            {
              
                if (ModelState.IsValid)
                {
                    Vital newVital = new Vital();
                    Patient newpatient = new Patient();
                    var wei = Convert.ToDouble(model.vital.Weight);
                    var hei = Convert.ToDouble(model.vital.Height);
                    model.vital.Bmi = Convert.ToString(wei/(hei*hei));
                    newVital = _patientRepository.AddAPC(model.vital);
                    newpatient = _patientRepository.GetPatient(model.vital.UserId);
                    rbmodel.patient = newpatient;
                    rbmodel.vital = newVital;
                }
                else
                {
                    return View();
                }

                return View("MedicalAssistantDashboard", rbmodel);
            }
            else if(commandSplit[0].ToLower() == "back" && userType == "MA")
            {
                RedBoxLayoutViewModel patient = createEmpty();
                return View("MedicalAssistantDashboard", patient);
            }
            else if (commandSplit[0].ToLower() == "logout")
            {
                userType = "";
                return View("Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ClerkDashboard(Patient _patient)
        {
            RedBoxLayoutViewModel pp = new RedBoxLayoutViewModel();
            pp.patient = _patient;
            return View(pp);
        }
        public IActionResult DoctorDashboard(RedBoxLayoutViewModel _patient)
        {
            
            return View(_patient);
        }
        public IActionResult MedicalAssistantDashboard(Patient patient)
        {
            RedBoxLayoutViewModel pp = new RedBoxLayoutViewModel();
            pp.patient = patient;
            return View(pp);
        }

        public IActionResult FamilyHistory(Patient patient)
        {
            RedBoxLayoutViewModel pp = new RedBoxLayoutViewModel();
            pp.patient = patient;
            return View(pp);
        }

        public IActionResult SocialHistory(SocialHistory socialhistory)
        {
            RedBoxLayoutViewModel sh = new RedBoxLayoutViewModel();
            sh.social = socialhistory;
            return View(sh);
        }

        public IActionResult Allergies(Allergies allergies)
        {
            RedBoxLayoutViewModel all = new RedBoxLayoutViewModel();
            all.allergy = allergies;
            return View(all);
        }



    }
}
