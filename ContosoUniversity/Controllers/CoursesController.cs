using ContosoUniversity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CoursesController : Controller
{
    private readonly SchoolContext _context;

    public CoursesController(SchoolContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _context.Courses.ToListAsync();
        return View(courses);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
        if (course == null) return NotFound();

        return View(course);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseID == id);
        if (course == null) return NotFound();

        return View(course);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
