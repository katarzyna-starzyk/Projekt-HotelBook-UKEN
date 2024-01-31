using Projekt.Models;
using WebApp.Models;

namespace Projekt.ViewModels
{
    public class RoomViewModel
    {
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public Room Room { get; set; } = new Room();
    }
}
