using System.Diagnostics;
using latvijas_pasts_mvc.DataBase;
using Microsoft.AspNetCore.Mvc;
using latvijas_pasts_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace latvijas_pasts_mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static CvDbContext _context;

    public HomeController(ILogger<HomeController> logger, CvDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var baseDataList = _context.Set<BaseData>().ToList();
        return View(baseDataList);
    }
    
    [HttpGet]
    public IActionResult ViewCV(int id)
    {
        var cv = _context.BaseData.FirstOrDefault(b => b.Id == id);
        if (cv == null)
        {
            return NotFound();
        }
        return View(cv);
    }
    
    [HttpPost]
    public IActionResult ViewCV(BaseData updatedData, bool? Delete)
    {
        if (Delete == true)
        {
            var cvToDelete = _context.Set<BaseData>().Find(updatedData.Id);
            if (cvToDelete != null)
            {
                _context.BaseData.Remove(cvToDelete);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        
        if (ModelState.IsValid)
        {
            _context.Update(updatedData);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(updatedData);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(BaseData data)
    {
        if (ModelState.IsValid)
        {
            _context.Add(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(data);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}