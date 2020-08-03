using HospitalManagement.Main.Models;
using HospitalManagement.Provider.Doctor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalManagement.Main.Controllers
{
    public class DoctorController : Controller
    {
        DoctorsProvider provider = new DoctorsProvider();
        // GET: Doctor
        public ActionResult Index()
        {
            List<DoctorModel> doctorsList = new List<DoctorModel>();
            DoctorModel doctor = new DoctorModel()
            {
                Id=-1,
                Name="",
                Password="",
                Designation="",
                SearchText=""
            };
            doctorsList = provider.GetDoctorsByCriteria(doctor,ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
            return View(doctorsList);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            DoctorModel doctor = new DoctorModel()
            {
                Id = id,
                Name = "",
                Password = "",
                Designation = "",
                SearchText = ""
            };
            provider.GetDoctorByCriteria(doctor, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
            return View(provider.GetDoctorByCriteria(doctor, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString));
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(DoctorModel doctors)
        {
            try
            {
                // TODO: Add insert logic here
                provider.InsertDoctor(doctors,ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            DoctorModel doctor = new DoctorModel()
            {
                Id = id,
                Name = "",
                Password = "",
                Designation = "",
                SearchText = ""
            };
            return View(provider.GetDoctorByCriteria(doctor, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString));
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(DoctorModel doctors)
        {
            try
            {
                // TODO: Add update logic here
                provider.UpdateDoctor(doctors, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            DoctorModel doctor = new DoctorModel()
            {
                Id = id,
                Name = "",
                Password = "",
                Designation = "",
                SearchText = ""
            };
            return View(provider.GetDoctorByCriteria(doctor, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString));
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                provider.DeleteDoctor(id, ConfigurationManager.ConnectionStrings["HMConnectionString"].ConnectionString);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
