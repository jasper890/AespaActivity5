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
    }
}
