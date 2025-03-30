using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onlinevotingsystem.Models;

namespace Onlinevotingsystem.Controllers
{
    public class CandidateController : Controller
    {
        private readonly OnlineVotingDB _context;

        public CandidateController(OnlineVotingDB context)
        {
            _context = context;
        }

        // GET: Candidate
        public async Task<IActionResult> Index()
        {
              return View(await _context.Candidate.ToListAsync());
        }
       
        // GET: Candidate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidate == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .FirstOrDefaultAsync(m => m.Candidateid == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidate/Create
        public IActionResult Create()
        {
            List<Election> electionList = new List<Election>();
            electionList = (from c in _context.Election select c).ToList();
            electionList.Insert(0, new Election { Electionid = 0, ElectionName = " --Select Election-- " });
            ViewBag.Election = electionList;
            return View();
        }

        // POST: Candidate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Candidateid,TypeElection,FirstName,LastName,DateOfBirth,Gender,email,password,Image,PhoneNo,address")] Candidate candidate)
        {
            var can = await _context.Candidate.Where(h => h.TypeElection == candidate.TypeElection).ToListAsync();
            if (ModelState.IsValid)
            {
                if(can.Count()<4)
                {
                    _context.Add(candidate);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
               ViewData["nospace"] = "There is no seats for Candidate to get registered";
                var v = ViewData["nospace"];
                ViewBag.seats = v;
                TempData["msg"] = "There is no seats for Candidate to get registered";
                return RedirectToAction(nameof(Create));
            }
            return View(candidate);
        }

        // GET: Candidate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidate == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Candidateid,TypeElection,FirstName,LastName,DateOfBirth,Gender,email,password,Image,PhoneNo,address")] Candidate candidate)
        {
            if (id != candidate.Candidateid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.Candidateid))
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
            return View(candidate);
        }

        // GET: Candidate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidate == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .FirstOrDefaultAsync(m => m.Candidateid == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidate == null)
            {
                return Problem("Entity set 'OnlineVotingDB.Candidate'  is null.");
            }
            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidate.Remove(candidate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
          return _context.Candidate.Any(e => e.Candidateid == id);
        }
    }
}
