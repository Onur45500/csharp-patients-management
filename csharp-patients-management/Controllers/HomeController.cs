using csharp_patients_management.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace csharp_patients_management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PatientsDbContext _context;

        public HomeController(ILogger<HomeController> logger, PatientsDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var allPatients = _context.Patients.ToList();

            return View(allPatients);
        }

        public IActionResult CreateOrEditPatientForm(Patient patient)
        {
            
            if(patient.Id == null)
            {
                _context.Patients.Add(patient);

                _context.SaveChanges();
            }
            else
            {
                _context.Patients.Update(patient);

                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        
        public IActionResult CreateOrEditPatient(int id)
        {
            var patientById = _context.Patients.SingleOrDefault(x => x.Id == id);

            if (id != null)
            {
                return View(patientById);
            }

            return View();
        }

        public IActionResult DeletePatient(int id)
        {
            var patientById = _context.Patients.SingleOrDefault(x => x.Id == id);

            _context.Patients.Remove(patientById);
            _context.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
