
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPopper.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Please provide a name")]
        public string Name { get; set; }

        [CustomValidation(typeof(Event), "EventDateInTheFuture")]
        [DataType(DataType.Date)]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Event Time")]
        public DateTime EventTime { get; set; }


        public string Type { get; set; }

        [Display(Name = "Total Seats")]
        [Required(ErrorMessage = "Please provide total number of seats")]
        public int TotalSeats { get; set; }

        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; }

        [Display(Name = "Host Name")]
        public string HostName { get; set; }

        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Please provide Street Address")]
        public string Location { get; set; }

        [Display(Name = "Ticket Count")]
        public int NumberOfTickets { get; set; }

        [Display(Name = "Ticket Price")]
        [System.ComponentModel.DefaultValue(0)]
        public decimal TicketPrice { get; set; }

        public decimal Discount { get; set; }

        public string Rating { get; set; }

        public string EventImageUrl { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Coupon> Coupons { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public bool IsRegistered {
            get {
                return RegistrationDate != null;
            }
        }

        public static ValidationResult EventDateInTheFuture(DateTime eventDate, ValidationContext context) {
            if (eventDate >= DateTime.Today) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Event date must be today or in the future");
        }

        [NotMapped]
        [Display(Name = "Net Pay")]
        public decimal NetPay
        {
            get
             {
                return TicketPrice - ((Discount/100)*TicketPrice);
             }
        }
    
    }
}
            