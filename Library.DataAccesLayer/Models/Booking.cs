using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccessLayer.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get;set; }
        public Guid TourId { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChild { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }

        public Tour Tour { get; set; }
        public Customer Customer { get; set; }  
    }
}
