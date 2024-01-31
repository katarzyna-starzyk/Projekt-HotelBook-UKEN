using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.ViewModels;
using WebApp.Models;

namespace Projekt.Controllers
{
    public class RoomsController : Controller
    {
        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            var rooms = RoomsRepository.GetRooms(loadCategory: true);
            return View(rooms);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            var roomViewModel = new RoomViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };

            return View(roomViewModel);
        }

        [HttpPost]
        public IActionResult Add(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                RoomsRepository.AddRoom(roomViewModel.Room);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            roomViewModel.Categories = CategoriesRepository.GetCategories();
            return View(roomViewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";

            var roomViewModel = new RoomViewModel
            {
                Room = RoomsRepository.GetRoomById(id)??new Room(),
                Categories = CategoriesRepository.GetCategories()
            };
            
            return View(roomViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid)
            {
                RoomsRepository.UpdateRoom(roomViewModel.Room.Id, roomViewModel.Room);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";

            roomViewModel.Categories = CategoriesRepository.GetCategories();
            return View(roomViewModel);
        }

        public IActionResult Delete(int id)
        {
            RoomsRepository.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RoomsByCategoryPartial(int categoryId)
        {
            var rooms = RoomsRepository.GetRoomsByCategoryId(categoryId);

            return PartialView("_Rooms", rooms);
        }
    }
}
