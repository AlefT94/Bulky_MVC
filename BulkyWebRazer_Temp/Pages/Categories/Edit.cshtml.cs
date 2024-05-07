using BulkyWebRazer_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazer_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            }
        }

        public IActionResult OnPost()
        {
            //Valida se a data-notations de validação estão corretas
            //Maxlenght, Range e etc...
            if (ModelState.IsValid)
            {
                //O update acontece com base no id enviado
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfuly";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
