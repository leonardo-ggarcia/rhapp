using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RH.Service;

namespace RH.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobService _jobService;

        public JobsController(JobService jobService)
        {
            _jobService = jobService;
        }
        public  async Task<IActionResult> Index()
        {
            var list = await _jobService.findAllAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        //I Stoped here... Necessary create a view Create
    }
}
