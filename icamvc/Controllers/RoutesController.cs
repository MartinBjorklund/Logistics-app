using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICAMVC.Data;
using ICAMVC.Models;
using Microsoft.AspNetCore.Authorization;
using ICAMVC.ViewModels;
using ICAMVC.Services;

namespace ICAMVC.Controllers
{
    [Authorize(Roles = "SuperAdmin,Transportledare,Lagerarbetare")]
    public class RoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoutesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult SendToDriver(int? id)
        {
            var route = _context.Route.Include(a => a.ListOfCoordinates).FirstOrDefault(a => a.Id.Equals(id));
            var gpsSmsNotice = route.ListOfCoordinates;
            var baseUrl = "https://www.google.com/maps/dir/";
            foreach (var item in gpsSmsNotice)
            {
                baseUrl = $"{baseUrl}{item.Longitude.ToString().Replace(',', '.')},{item.Latitude.ToString().Replace(',', '.')}/";
            }
            SmsService.SendMessage(baseUrl);
            return RedirectToAction("Index");
        }

        public IActionResult Maps(int? id)
        {
            var route = _context.Route.Include(a => a.ListOfCoordinates).FirstOrDefault(a => a.Id.Equals(id));

            return View(route);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            var routes = await _context.Route.Include(a => a.Driver).ToListAsync();
            return Ok(routes);
        }

        // GET: Routes
        public async Task<IActionResult> Index()
        {
            var ListOfDrivers = await _context.Driver.ToListAsync();

            if (ListOfDrivers.Count == 0)
            {
                var defaultDrivers = new List<Driver>();
                defaultDrivers.Add(new Driver { Name = "Jacob", BadgeId = 1 });
                defaultDrivers.Add(new Driver { Name = "Jesper", BadgeId = 2 });
                defaultDrivers.Add(new Driver { Name = "Jenny", BadgeId = 3 });
                foreach (var driver in defaultDrivers)
                {
                    _context.Driver.Add(driver);
                }

                await _context.SaveChangesAsync();
            }

            var ListOfRealDrivers = await _context.Driver.ToListAsync();
            //If list is empty, generate demo-routes
            var routes = await _context.Route.ToListAsync();
            if (routes.Count == 0)
            {
                var listOfRoutes = RenderRoutes.Generate();
                foreach (var route in listOfRoutes)
                {
                    route.Driver = ListOfRealDrivers[0];
                    _context.Add(route);
                }

                await _context.SaveChangesAsync();
            }




            RouteViewModel model = new RouteViewModel();
            model.ListOfRoutes = await _context.Route.ToListAsync();
            model.ListOfDrivers = await _context.Driver.ToListAsync();

            return View(model);
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Route
                .FirstOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RouteName,StartTime,StopTime,Distance,NumberOfCustomers,AllDone,PickingDone,FreezerDone,NumberOfFreezeBags,NumberOfPickingBoxes")] Route route)
        {
            if (ModelState.IsValid)
            {
                _context.Add(route);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // GET: Routes/Edit/5
        [Authorize(Roles = "SuperAdmin,Transportledare")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Route.FindAsync(id);
            var drivers = await _context.Driver.ToListAsync();
            route.Drivers = drivers;
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin,Transportledare")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] Driver driver, [Bind("Id,RouteName,StartTime,StopTime,Distance,NumberOfCustomers,AllDone,PickingDone,FreezerDone,NumberOfFreezeBags,NumberOfPickingBoxes")] Route route)
        {
            if (id != route.Id)
            { 
                return NotFound();
            }
            var ThisDriver = _context.Driver.FirstOrDefault(x => x.Name.Equals(driver.Name));
            route.Driver = ThisDriver;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        [Authorize(Roles = "SuperAdmin,Transportledare,Lagerarbetare")]
        [HttpPost]
        public async Task<IActionResult> EditDriver([FromBody] Route route, [Bind("Name")] Driver driver)
        {
            var savedRoute = _context.Route.Include(a=>a.Driver).FirstOrDefault(a => a.Id.Equals(route.Id));

            if (savedRoute == null)
            {
                return NotFound();
            }
 
            if (savedRoute.TruckLoaded != route.TruckLoaded)
            {
                savedRoute.TruckLoaded = route.TruckLoaded;
            }
            if (savedRoute.NumberOfParcels != route.NumberOfParcels)
            {
                savedRoute.NumberOfParcels = route.NumberOfParcels;
            }

            await _context.SaveChangesAsync();
                return Ok("Updated");
        }

        // GET: Routes/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var route = await _context.Route
                .FirstOrDefaultAsync(m => m.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var route = await _context.Route.FindAsync(id);
            _context.Route.Remove(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return _context.Route.Any(e => e.Id == id);
        }
    }
}
