using Chtoto.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Chtoto.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(dataManager.textFields.GetTextFieldByCodeWord("PageIndex"));
        }

        public IActionResult Contacts()
        {
            return View(dataManager.textFields.GetTextFieldByCodeWord("PageContacts"));
        }
    }
}
