using Colors.DAL.Context;
using Colors.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Colors.Web.Controllers
{
    public class HomeController : Controller
    {
        private ColorContext _context;

        public HomeController(ColorContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<string> AddColor(string colorName)
        {

            var message = string.Empty;
            try
            {
                var checkExistColor = _context.Colors.Any(e => e.ColorName == colorName);

                if (checkExistColor)
                {
                    message = "Данный цвет зарегистрирован ранее";
                }
                else
                {
                    var color = new ColorEntity()
                    {
                        ColorName = colorName
                    };

                    _context.Colors.Add(color);

                    await _context.SaveChangesAsync();

                    message = "Цвет успешно зарегистрирован";
                }
            }
            catch (Exception ex)
            {
                message = $"Что-то пошло не так, мы словили ошибку. {ex.Message}";
            }
            return message;
        }

    }
}