using Projekt.Models;
using System.ComponentModel.DataAnnotations;

namespace Projekt.ViewModels
{
    public class BookingViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int SelectedRoomId { get; set; }

        [Display(Name = "Quantity")]
        [Range(1, int.MaxValue)]
        //[BookingViewModel_EnsureProperQuantity]
        public int QuantityToBook { get; set;}
    }
}
