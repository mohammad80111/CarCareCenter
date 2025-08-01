using CarCenter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarCenter.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext appDb)
        {
           _context = appDb;


        }


        [HttpGet]
        public IActionResult Index()
        {
            List <Booking> lista=_context.bookings.Include(c=>c.roll).Include(c=>c.employee).Include(c=>c.carSize).ToList();
            return View(lista);
        }



        [HttpGet]
        public IActionResult Create()
        {
            SelectRool();
            SelectCarSize();
            SelectEmployee();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Booking booking)
        {
            _context.bookings.Add(booking); 
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int? ID)
        {
            SelectRool();
            SelectCarSize();
            SelectEmployee();
            var user = _context.bookings.Find(ID);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(Booking booking)
        {
            _context.bookings.Update(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public ViewResult Delete(int ID)
        {
            Booking B1 = (from bok in _context.bookings
                          where bok.Id == ID    
                          select bok
                          ).FirstOrDefault();

            _context.bookings.Remove(B1);
            _context.SaveChanges();
            List<Booking> lista = _context.bookings.Include(c => c.roll).Include(c => c.employee).Include(c => c.carSize).ToList();
             return View("Index",lista);


        }



        public void SelectRool(int selectid=0)
        {
            List<Roll> listRoll = _context.rolls.ToList();

            SelectList selectListItems = new SelectList(listRoll, "RollID", "RollName", selectid);

            ViewBag.selectrool=selectListItems;
        }




        public void SelectCarSize(int selectid = 0)
        {
            List<CarSize> listcarsize = _context.carSizes.ToList();

            SelectList selectListItems = new SelectList(listcarsize, "CarSizeID", "CarSizeName", selectid);

            ViewBag.selectcarsize = selectListItems;
        }

     

        public void SelectEmployee(int selectid = 0)
        {
            List<Employee> listemployee = _context.employees.ToList();

            SelectList selectListItems = new SelectList(listemployee, "EmployeeID", "EmployeeName", selectid);

            ViewBag.selectemployee = selectListItems;
        }




    }
}
