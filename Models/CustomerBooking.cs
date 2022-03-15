using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class CustomerBooking
    {
        public string id { get; set; }
        public string customerName { get; set; }
        public string customerMobile { get; set; }
        public string customerEmailAddress { get; set; }
        public string customerAddress { get; set; }
        public string customerLocation { get; set; }
        public decimal amountPaid { get; set; }
        public int daysBooked { get; set; }
        public DateTime? checkInDate { get; set; }
        public bool? isCheckedOut { get; set; }
    }
}
