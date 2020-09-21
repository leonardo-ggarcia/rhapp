using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;
using RH.Data;
using RH.Models;
using RH.Models.ViewModels;
using RH.Service;

namespace RH.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly CandidateService _candidateService;
        private readonly TechnologyService _technologyService;
        private readonly JobService _jobService;
        private readonly RHContext _context;


        public CandidatesController(CandidateService candidateService, TechnologyService technologyService, JobService jobService, RHContext context)
        {
            _candidateService = candidateService;
            _technologyService = technologyService;
            _jobService = jobService;
            _context = context;
        }


        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            return View(await _candidateService.findAllAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _candidateService.findByIdAsync(id.Value);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public async Task<IActionResult> Create()
        {
            var jobs = await _jobService.findAllAsync();
            var technologies = await _technologyService.findAllAsync();
            var viewModels = new CandidateFormViewModels { Jobs = jobs, Technologies = technologies };
            return View(viewModels);
        }

        // POST: Candidates/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate candidate)
        {

            //Cand_Tech cand_Tech = new Cand_Tech);           
            if (ModelState.IsValid)
            {
                                
                //await _context.Cand_Tech.AddAsync();
                // await _context.SaveChangesAsync();

                await _candidateService.insertAsync(candidate);
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _candidateService.findByIdAsync(id.Value);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Age,Address,City,Phone,Email")] Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _candidateService.UpdateAsync(candidate);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _candidateService.findByIdAsync(id.Value);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _candidateService.removeAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
