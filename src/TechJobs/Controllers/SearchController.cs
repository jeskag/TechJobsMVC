using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        //static List<Dictionary<string, string>> AllJobs = new List<Dictionary<string, string>>();

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> Jobs;
            if (searchType.Equals("all"))
            {
               Jobs = JobData.FindByValue(searchTerm);
                //ViewBag.columns = ListController.columnChoices;
            }
            else
            {
                Jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                //ViewBag.columns = ListController.columnChoices;
            }
            ViewBag.jobs = Jobs;
            return View("Index");
        }
    }
}