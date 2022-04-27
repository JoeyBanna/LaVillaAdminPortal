using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public decimal balance { get; set; }
        public int daysBooked { get; set; }
        public DateTime? checkInDate { get; set; }
        public DateTime checkedInAt { get; set; }
        public bool? isCheckedOut { get; set; }
        public DateTime checkedOutAt { get; set; }
        public string currency { get; set; }
        public string dateOfBookings { get; set; }
    }
    public class Cust
    {
        public string id { get; set; }
        public string customerName { get; set; }
        public string customerMobile { get; set; }
        public string customerEmailAddress { get; set; }
        public string customerAddress { get; set; }
        public string customerLocation { get; set; }
        public int amountPaid { get; set; }
        public int balance { get; set; }
        public int daysBooked { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkedInAt { get; set; }
        public bool isCheckedOut { get; set; }
    }

}
