using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onlinevotingsystem.Models;

namespace Onlinevotingsystem.Controllers
{
    public class ElectionVotesController : Controller
    {
        private readonly OnlineVotingDB _context;

        public ElectionVotesController(OnlineVotingDB context)
        {
            _context = context;
        }

        // GET: ElectionVotes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ElectionVotes.ToListAsync());
        }
        

        // GET: ElectionVotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ElectionVotes == null)
            {
                return NotFound();
            }

            var electionVotes = await _context.ElectionVotes
                .FirstOrDefaultAsync(m => m.ElectionVoteId == id);
            if (electionVotes == null)
            {
                return NotFound();
            }

            return View(electionVotes);
        }

        // GET: ElectionVotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ElectionVotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ElectionVoteId,UserId,ElectionId,CandidateId")] ElectionVotes electionVotes)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(electionVotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(electionVotes);
        }

        // GET: ElectionVotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ElectionVotes == null)
            {
                return NotFound();
            }

            var electionVotes = await _context.ElectionVotes.FindAsync(id);
            if (electionVotes == null)
            {
                return NotFound();
            }
            return View(electionVotes);
        }

        // POST: ElectionVotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ElectionVoteId,UserId,ElectionId,CandidateId")] ElectionVotes electionVotes)
        {
            if (id != electionVotes.ElectionVoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(electionVotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElectionVotesExists(electionVotes.ElectionVoteId))
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
            return View(electionVotes);
        }

        // GET: ElectionVotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ElectionVotes == null)
            {
                return NotFound();
            }

            var electionVotes = await _context.ElectionVotes
                .FirstOrDefaultAsync(m => m.ElectionVoteId == id);
            if (electionVotes == null)
            {
                return NotFound();
            }

            return View(electionVotes);
        }

        // POST: ElectionVotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ElectionVotes == null)
            {
                return Problem("Entity set 'OnlineVotingDB.ElectionVotes'  is null.");
            }
            var electionVotes = await _context.ElectionVotes.FindAsync(id);
            if (electionVotes != null)
            {
                _context.ElectionVotes.Remove(electionVotes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElectionVotesExists(int id)
        {
          return _context.ElectionVotes.Any(e => e.ElectionVoteId == id);
        }
    }
}
