using BlogManagementApp.Data;
using BlogManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogManagementApp.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly BlogManagementDBContext _context;
        /// <summary>
        /// Injects the BlogManagementDBContext to access category data from the database.
        /// </summary>
        /// <param name="context"></param>
        public CategoriesViewComponent(BlogManagementDBContext context )
        {
            _context = context;
        }

        /// <summary>
        /// InvokeAsync Method: Asynchronously fetches all categories ordered by name and passes them to the corresponding view.
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            //View Location shuld be : Views/Shared/Components/Categories/Default.cshtml
            return View(categories);
        }
    }
}
