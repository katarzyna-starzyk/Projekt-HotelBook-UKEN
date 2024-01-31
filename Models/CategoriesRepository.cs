using WebApp.Models;

namespace Projekt.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>
        {
            new() {Id = 1, Name = "Single", Description = "A room assigned to one person. May have one or more beds"},
            new() {Id = 2, Name = "Double", Description = "A room assigned to two people. May have one or more beds"},
            new() {Id = 3, Name = "Triple", Description = "A room that can accommodate three persons and has been fitted with three twin beds, one double bed and one twin bed or two double beds."},
            new() {Id = 4, Name = "Quad", Description = "A room assigned to four people. May have two or more beds."},
            new() {Id = 5, Name = "Twin", Description = "A room with two twin beds. May be occupied by one or more people."},
            new() {Id = 6, Name = "Studio", Description = "A room with a studio bed - a couch which can be converted into a bed. May also have an additional bed."},
            new() {Id = 7, Name = "Suite", Description = "A parlour or living room connected with to one or more bedrooms. (A room with one or more bedrooms and a separate living space.)"},
            new() {Id = 8, Name = "Connecting rooms", Description = "Rooms with individual entrance doors from the outside and a connecting door between. Guests can move between rooms without going through the hallway."},
            new() {Id = 9, Name = "Accessible Room", Description = "This room type is mainly designed for disabled guests."}
        };

        public static void AddCategory(Category category)
        {
            if (_categories != null && _categories.Count > 0)
            {
                var maxId = _categories.Max(c => c.Id);
                category.Id = maxId + 1;
            }
            else
            {
               category.Id = 0;
            }

            if (_categories == null) _categories = new List<Category>();

            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int Id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == Id);
            if (category != null)
            {
                return new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }

            return null;
        }

        public static void UpdateCategory(int Id, Category category)
        {
            if (Id != category.Id)
            {
                return;
            }

            var categoryToUpdate = _categories.FirstOrDefault(c => c.Id == Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int Id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == Id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}
