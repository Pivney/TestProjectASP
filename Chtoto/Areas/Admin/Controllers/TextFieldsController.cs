using Microsoft.AspNetCore.Mvc;
using Chtoto.Domain;
using Chtoto.Domain.Enteties;
using Chtoto.Service;
using Chtoto.Controllers;

namespace MyCompany.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;
        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.textFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            /*
            if (ModelState.IsValid)
            {
                dataManager.textFields.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            */
            return View(model);
            
        }

    }
}