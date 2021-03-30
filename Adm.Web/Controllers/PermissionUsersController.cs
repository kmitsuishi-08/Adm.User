using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Adm.Web.Contexts;
using Adm.Web.Models;

namespace Adm.Web.Controllers
{
    public class PermissionUsersController : Controller
    {
        private readonly TestContext _context;

        public PermissionUsersController(TestContext context)
        {
            _context = context;
        }

        // GET: PermissionUsers
        public async Task<IActionResult> Index()
        {
            var testContext = _context.PermissionUsers.Include(p => p.Permission).Include(p => p.User);
            return View(await testContext.ToListAsync());
        }

        // GET: PermissionUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionUser = await _context.PermissionUsers
                .Include(p => p.Permission)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permissionUser == null)
            {
                return NotFound();
            }

            return View(permissionUser);
        }

        // GET: PermissionUsers/Create
        public IActionResult Create()
        {
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName");
            return View();
        }

        // POST: PermissionUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PermissionId,UserId")] PermissionUser permissionUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permissionUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Description", permissionUser.PermissionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", permissionUser.UserId);
            return View(permissionUser);
        }

        // GET: PermissionUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionUser = await _context.PermissionUsers.FindAsync(id);
            if (permissionUser == null)
            {
                return NotFound();
            }
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Description", permissionUser.PermissionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", permissionUser.UserId);
            return View(permissionUser);
        }

        // POST: PermissionUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PermissionId,UserId")] PermissionUser permissionUser)
        {
            if (id != permissionUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permissionUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermissionUserExists(permissionUser.Id))
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
            ViewData["PermissionId"] = new SelectList(_context.Permissions, "Id", "Description", permissionUser.PermissionId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FirstName", permissionUser.UserId);
            return View(permissionUser);
        }

        // GET: PermissionUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permissionUser = await _context.PermissionUsers
                .Include(p => p.Permission)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (permissionUser == null)
            {
                return NotFound();
            }

            return View(permissionUser);
        }

        // POST: PermissionUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permissionUser = await _context.PermissionUsers.FindAsync(id);
            _context.PermissionUsers.Remove(permissionUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermissionUserExists(int id)
        {
            return _context.PermissionUsers.Any(e => e.Id == id);
        }
    }
}
