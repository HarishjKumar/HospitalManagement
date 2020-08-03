using HospitalManagement.Main.Models;
using HospitalManagement.Provider.Patient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Main.Controllers
{
    public class PatientController : Controller
    {
        PatientsProvider provider = new PatientsProvider();
        // GET: Patient
        public ActionResult Index()
        {
            PatientModel Patient = new PatientModel()
            {
                PatientId = -1,
                PatientName = "",
                Department = "",
                Consultant = "",
                SearchText = ""
            };
            return View(provider.GetPatientsByCriteria(Patient, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString));
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            PatientModel Patient = new PatientModel()
            {
                PatientId = id,
                PatientName = "",
                Department = "",
                Consultant = "",
                SearchText = ""
            };
            provider.GetPatientByCriteria(Patient, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
            return View(provider.GetPatientByCriteria(Patient, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString));
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(PatientModel patient)
        {
            try
            {
                // TODO: Add insert logic here
                provider.InsertPatient(patient, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            PatientModel Patient = new PatientModel()
            {
                PatientId = id,
                PatientName = "",
                Department = "",
                Consultant = "",
                SearchText = ""
            };
            return View(provider.GetPatientByCriteria(Patient, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString));
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(PatientModel patient)
        {
            try
            {
                // TODO: Add update logic here
                provider.UpdatePatient(patient, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            PatientModel Patient = new PatientModel()
            {
                PatientId = id,
                PatientName = "",
                Department = "",
                Consultant = "",
                SearchText = ""
            };
            return View(provider.GetPatientByCriteria(Patient, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString));
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                provider.DeletePatient(id, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
