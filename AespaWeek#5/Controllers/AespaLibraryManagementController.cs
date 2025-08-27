using Microsoft.AspNetCore.Mvc;

namespace AespaWeek_5.Controllers
{
    public class AespaLibraryManagementController : Controller
    {
       
         private readonly Data.DataContext _context;    

        public AespaLibraryManagementController(Data.DataContext context)
            {
            _context = context;
        }
        public IActionResult Index()
        {
            var records = _context.LibraryRecords.ToList();
            return View(records);
        }
        [HttpPost]
        public IActionResult AddRecord(Models.LibraryRecord record)
        {
            if (ModelState.IsValid)
            {
                _context.LibraryRecords.Add(record);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index", _context.LibraryRecords.ToList());
        }
        [HttpGet]
        public IActionResult DeleteRecord(int id)
        {
            var record = _context.LibraryRecords.Find(id);
            if (record != null)
            {
                _context.LibraryRecords.Remove(record);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
