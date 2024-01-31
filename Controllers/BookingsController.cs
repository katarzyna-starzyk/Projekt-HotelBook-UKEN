using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.ViewModels;

namespace Projekt.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            var bookingViewModel = new BookingViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(bookingViewModel);
        }

        public IActionResult BookRoomPartial(int roomId)
        {
            var room = RoomsRepository.GetRoomById(roomId);
            return PartialView("_BookRoom", room);
        }
    }
}
