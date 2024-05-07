using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitofWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitofWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitofWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            //Exemple of an custom validation
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannote exactly match the Name");
            }

            //Valida se a data-notations de validação estão corretas
            //Maxlenght, Range e etc...
            if (ModelState.IsValid)
            {
                _unitofWork.Category.Add(category);
                _unitofWork.Save();
                TempData["success"] = "Category created successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Busca com base na primary key da model
            //Category category = _db.Categories.Find(id);

            //Busca utilizando linq, util quando não é a primary key
            //Category category = _db.Categories.FirstOrDefault(u=> u.Id == id);

            //Mesmo resultado do anterior, é mais utilizando quando tem maiores filtros
            //no where, se for uma busca simples, o FirstOrDefault é melhor
            Category category = _unitofWork.Category.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            //Valida se a data-notations de validação estão corretas
            //Maxlenght, Range e etc...
            if (ModelState.IsValid)
            {
                //O update acontece com base no id enviado
                _unitofWork.Category.Update(category);
                _unitofWork.Save();
                TempData["success"] = "Category updated successfuly";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _unitofWork.Category.Get(u => u.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Category? category = _unitofWork.Category.Get(u => u.Id == id);
            if (category == null)
            {
                return NotFound(id);
            }
            _unitofWork.Category.Remove(category);
            _unitofWork.Save();
            TempData["success"] = "Category deleted successfuly";
            return RedirectToAction("Index");

        }

    }
}
