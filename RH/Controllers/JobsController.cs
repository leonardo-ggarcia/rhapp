using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Models;
using RH.Models.ViewModels;
using RH.Service;

namespace RH.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobService _jobService;
        private readonly TechnologyService _technologyService;
        private readonly CandidateService _candidateService;

        public JobsController(JobService jobService, TechnologyService technologyService, CandidateService candidateService)
        {
            _jobService = jobService;
            _technologyService = technologyService;
            _candidateService = candidateService;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            return View(await _jobService.findAllAsync());
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _jobService.findByIdAsync(id.Value);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public  IActionResult Create()
        {            
            return View();
        }

        // POST: Jobs/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Amount")] Job job)
        {
            if (ModelState.IsValid)
            {              

                await _jobService.insertAsync(job);
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _jobService.findByIdAsync(id.Value);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Amount")] Job job)
        {
            if (id != job.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _jobService.UpdateAsync(job);
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _jobService.findByIdAsync(id.Value);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _jobService.removeAsync(id);
            return RedirectToAction(nameof(Index));
        }           
        
    }   
}
