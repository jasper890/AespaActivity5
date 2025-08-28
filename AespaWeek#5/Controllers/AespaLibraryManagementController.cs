using AespaWeek_5.Data;
using AespaWeek_5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AespaWeek_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AespaLibraryManagementController : Controller
    {
        private readonly DataContext _context;

        public AespaLibraryManagementController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<LibraryRecord>> GetAllInfo()
        {
            var records = await _context.LibraryRecords.ToListAsync();
            return Ok(records);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LibraryRecord>> GetInfo(int id)
        {
            var record = await _context.LibraryRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        public async Task<ActionResult<LibraryRecord>> CreateInfo(LibraryRecord record)
        {
            if (record.ReturnDate.HasValue && record.BorrowDate.HasValue &&
                 record.ReturnDate < record.BorrowDate)
            {
                return BadRequest("Return date must be on or after borrow date");
            }
            // auto set availability
            record.Available = !record.ReturnDate.HasValue; 
            _context.LibraryRecords.Add(record);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                Message = $"Record created successfully with ID {record.RecordId}",
                Record = record
            });
        }

        [HttpPut("{id}/available")]
        public async Task<ActionResult<LibraryRecord>> UpdateStatus(int id, [FromBody] bool updateAvailability)
        {

            var record = await _context.LibraryRecords.FindAsync(id);
            if (record == null)
                return NotFound("ID not found.");

            record.Available = updateAvailability;
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.LibraryRecords.Any(e => e.RecordId == id))
                    return NotFound();
                else
                    throw;
            }
            return Ok(new
            {
            Message = $"Availability status has been updated to {updateAvailability}",
            UpdatedRecord = record
            });
        }
        [HttpPut("{id}/Author")]
        public async Task<ActionResult<LibraryRecord>> updateAuthorName(int id, [FromBody] string UpdateAuthorName)
        { 
            var record = await _context.LibraryRecords.FindAsync(id);
            if (record == null)
            { 
                return NotFound("ID not found.");
            }
            record.BookAuthor = UpdateAuthorName;
            try 
            { 
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.LibraryRecords.Any(e => e.RecordId == id))
                    return NotFound();
                else
                    throw;
            }
            return Ok($"Author has been updated to {UpdateAuthorName}"); 
        }
        [HttpPut]

        [HttpDelete]
        public async Task<ActionResult<LibraryRecord>> DeleteLibraryRecord(int id)
        {
            var record = await _context.LibraryRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            _context.LibraryRecords.Remove(record);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
