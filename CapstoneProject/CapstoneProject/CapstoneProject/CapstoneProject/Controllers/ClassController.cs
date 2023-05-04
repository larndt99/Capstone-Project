using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.PowerBI.Api;
using CapstoneProject.Entities;
using CapstoneProject.DataAccess;
using CapstoneProject.Models;
using System.IO;

namespace CapstoneProject.Controllers
{
    public class ClassController : Controller
    {
        public ClassController(ClassDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public IActionResult List()
        {
            var timesheets = _studentDbContext.Classes.OrderBy(m => m.ClassName).ToList();

            return View(timesheets);
        }

        public IActionResult RegisterList(int Id)
        {

            var timesheets = _studentDbContext.Clients
                .Include(c => c.Class)
        .Where(c => c.ClassId == Id)
        .ToList();
            return View(timesheets);
        }

        public IActionResult InstructorList(int Id)
        {

            var timesheets = _studentDbContext.Instructorss.OrderBy(m => m.InstructorId).ToList();

            return View(timesheets);

        }
        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ClassViewModel studentViewModel = new ClassViewModel()
            {
                ClassId = _studentDbContext.Classes.OrderBy(g => g.ClassName).ToList(),
                ActiveClass = new Class()
            };

            return View(studentViewModel);
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ClassViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _studentDbContext.Classes.Add(studentViewModel.ActiveClass);
                _studentDbContext.SaveChanges();
                return RedirectToAction("List", "Class");
            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view again:
                studentViewModel.ClassId = _studentDbContext.Classes.OrderBy(g => g.ClassName).ToList();
                return View(studentViewModel);
            }
        }

        [HttpGet()]
        // [Authorize()]
        public IActionResult Edit(int id)
        {
            InstructorViewModel studentViewModel = new InstructorViewModel()
            {

                InstructorId = _studentDbContext.Instructorss.Include(m => m.Class).Where(m => m.ClassId == id).OrderBy(g => g.InstructorId).ToList(),
                ActiveInstructor = _studentDbContext.Instructorss.Find(id)

            };
            Classsid = id;
            return View(studentViewModel);
        }
        [HttpPost()]
        public async Task<IActionResult> Edit(InstructorViewModel studentViewModel)
        {

            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _studentDbContext.Instructorss.Update(studentViewModel.ActiveInstructor);
                //_studentDbContext.SaveChanges();
                await _studentDbContext.SaveChangesAsync();
                return RedirectToAction("List", "Class");
                // return RedirectToAction("List", "Class");

            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view again:
                studentViewModel.InstructorId = _studentDbContext.Instructorss.OrderBy(g => g.InstructorName).ToList();
                return View(studentViewModel);
            }
        }

        [HttpGet()]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            // Find/retrieve/select the movie to edit and then pass it to the view:
            var student = _studentDbContext.Classes.Find(id);
            return View(student);
        }

        [HttpPost()]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Class student)
        {
            // Simply remove the movie and then redirect back to the all movies view:
            _studentDbContext.Classes.Remove(student);
            _studentDbContext.SaveChanges();
            return RedirectToAction("List", "Class");
        }


        [HttpGet()]
        // [Authorize()]
        public IActionResult Register(int id)
        {
            ClientViewModel studentViewModel = new ClientViewModel()
            {

                ClientId = _studentDbContext.Clients.Include(m => m.Class).Where(m => m.ClassId == id).OrderBy(g => g.ClientId).ToList(),
                ActiveClient = new Client(),
                ClassId = id
            };
            Classsid = id;
            return View(studentViewModel);
        }

        public IActionResult Index()
        {
            int totalClients = _studentDbContext.Clients.Count();
            return View(totalClients);
        }

        [HttpPost()]
        public async Task<IActionResult> Register(ClientViewModel studentViewModel)
        {

            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _studentDbContext.Clients.Add(studentViewModel.ActiveClient);
                //_studentDbContext.SaveChanges();
                await _studentDbContext.SaveChangesAsync();
                return RedirectToAction("Register", "Class");
                // return RedirectToAction("List", "Class");

            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view again:
                studentViewModel.ClientId = _studentDbContext.Clients.OrderBy(g => g.ClientName).ToList();
                return View(studentViewModel);
            }
        }
        [HttpGet()]

        public IActionResult DeleteClient(int id)
        {
            // Find/retrieve/select the movie to edit and then pass it to the view:
            var student = _studentDbContext.Clients.Find(id);
            return View(student);
        }

        [HttpPost()]

        public IActionResult DeleteClient(Client student)
        {
            // Simply remove the movie and then redirect back to the all movies view:
            _studentDbContext.Clients.Remove(student);
            _studentDbContext.SaveChanges();
            return RedirectToAction("List", "Class");
        }

        public IActionResult DeleteInstructor(int id)
        {
            // Find/retrieve/select the movie to edit and then pass it to the view:
            var student = _studentDbContext.Instructorss.Find(id);
            return View(student);
        }

        [HttpPost()]
        //  [Authorize(Roles = "Admin")]
        public IActionResult DeleteInstructor(Instructor student)
        {
            // Simply remove the movie and then redirect back to the all movies view:
            _studentDbContext.Instructorss.Remove(student);
            _studentDbContext.SaveChanges();
            return RedirectToAction("List", "Class");
        }

        private int Classsid;

        [HttpGet()]
        // [Authorize()]
        public IActionResult InstructorCreate(int id)
        {
            InstructorViewModel studentViewModel = new InstructorViewModel()
            {

                InstructorId = _studentDbContext.Instructorss.Include(m => m.Class).Where(m => m.ClassId == id).OrderBy(g => g.InstructorId).ToList(),
                ActiveInstructor = new Instructor(),
                ClassId = id
            };
            Classsid = id;
            return View(studentViewModel);
        }


        [HttpPost()]
        public async Task<IActionResult> InstructorCreate(InstructorViewModel studentViewModel)
        {

            if (ModelState.IsValid)
            {
                // it's valid so we want to add the new movie to the DB:
                _studentDbContext.Instructorss.Add(studentViewModel.ActiveInstructor);
                //_studentDbContext.SaveChanges();
                await _studentDbContext.SaveChangesAsync();
                return RedirectToAction("List", "Class");
                // return RedirectToAction("List", "Class");

            }
            else
            {
                // it's invalid so we simply return the movie object
                // to the Edit view again:
                studentViewModel.InstructorId = _studentDbContext.Instructorss.OrderBy(g => g.InstructorName).ToList();
                return View(studentViewModel);
            }
        }


        private ClassDbContext _studentDbContext;
    }
}