using Anti_Cafe.Interfaces;
using Anti_Cafe.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Anti_Cafe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDBProvider _provider;

        public HomeController(IDBProvider provider)
        {
           _provider = provider;
        }

        public async Task<IActionResult> Index()
        {            
            return View(await _provider.GetStatuette());
        }
        [HttpPost]
        public async Task<IActionResult> CreateStatuette(string name)
        {
             
            return PartialView("_TableStatuette", await _provider.CReateStatuette(name));
        }
        
        public async Task<IActionResult> DeleteStatuette(string name)
        {

            return PartialView("_TableStatuette", await _provider.DeleteStatuette(name));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}