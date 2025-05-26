namespace PVOrderTracker.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string WatchName { get; set; }
        public string TrackingNumber { get; set; }
        public string TrackingCourier { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; } // Completed, Pending, Cancelled
    }
}