namespace Projekt.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = "";
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; } = "";
    }
}
