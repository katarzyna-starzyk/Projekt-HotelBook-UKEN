using WebApp.Models;

namespace Projekt.Models
{
    public class RoomsRepository
    {
        private static List<Room> _rooms = new List<Room>()
        {
            new() {Id = 1, CategoryId = 1, Name = "Room class A", Quantity = 3, Price = 300.00},
            new() {Id = 2, CategoryId = 1, Name = "Room class B", Quantity = 5, Price = 200.00},
            new() {Id = 3, CategoryId = 1, Name = "Room class C", Quantity = 7, Price = 150.00},
            new() {Id = 4, CategoryId = 2, Name = "Room class A", Quantity = 3, Price = 600.00},
            new() {Id = 5, CategoryId = 2, Name = "Room class B", Quantity = 5, Price = 400.00},
            new() {Id = 6, CategoryId = 2, Name = "Room class C", Quantity = 7, Price = 300.00},
            new() {Id = 7, CategoryId = 3, Name = "Room class A", Quantity = 3, Price = 900.00},
            new() {Id = 8, CategoryId = 3, Name = "Room class B", Quantity = 5, Price = 600.00},
            new() {Id = 9, CategoryId = 3, Name = "Room class C", Quantity = 7, Price = 450.00},
        };

        public static void AddRoom(Room room)
        {
            if(_rooms != null && _rooms.Count > 0)
            {
                var maxId = _rooms.Max(r => r.Id);
                room.Id = maxId + 1;
            }
            else
            {
                room.Id = 0;
            }

            if (_rooms == null) _rooms = new List<Room>();
            _rooms.Add(room);
        }

        public static List<Room> GetRooms(bool loadCategory = false)
        {
            if (!loadCategory)
            {
                return _rooms;
            }
            else
            {
                if (_rooms != null && _rooms.Count>0)
                {
                    _rooms.ForEach(r =>
                    {
                        if (r.CategoryId.HasValue)
                            r.Category = CategoriesRepository.GetCategoryById(r.CategoryId.Value);

                    });
                }

                return _rooms??new List<Room>();
            }
        }

        public static Room? GetRoomById(int id, bool loadCategory = false)
        {
            var room = _rooms.FirstOrDefault(x => x.Id == id);
            if (room != null)
            {
                var r = new Room
                { 
                    Id = room.Id,
                    Name = room.Name,
                    Quantity = room.Quantity,
                    Price = room.Price,
                    CategoryId = room.CategoryId
                };

                if(loadCategory && r.CategoryId.HasValue)
                {
                    r.Category = CategoriesRepository.GetCategoryById(r.CategoryId.Value);
                }

                return r;
            }

            return null;
        }

        public static void UpdateRoom(int id, Room room)
        {
            if (id != room.Id) return;

            var roomToUpdate = _rooms.FirstOrDefault(r => r.Id == id);
            if (roomToUpdate != null)
            {
                roomToUpdate.Name = room.Name;
                roomToUpdate.Quantity = room.Quantity;
                roomToUpdate.Price = room.Price;
                roomToUpdate.CategoryId = room.CategoryId;
            }
        }

        public static void DeleteRoom(int id)
        {
            var room = _rooms.FirstOrDefault(_r => _r.Id == id);
            if (room != null)
            {
                _rooms.Remove(room);
            }
        }

        public static List<Room> GetRoomsByCategoryId(int categoryId)
        {
            var rooms = _rooms.Where(x => x.CategoryId == categoryId);
            if (rooms != null)
                return rooms.ToList();
            else
                return new List<Room> { };
        }
    }
}
