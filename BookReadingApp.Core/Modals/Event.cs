using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookReadingApp.Core.Modals
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Title of the Book")]
        [Display(Name = "Title of the Book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please Enter the Event Date")]
        [Display(Name = "Event Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter the Start Date")]
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please enter the Location")]
        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Range(1, 4, ErrorMessage = "Duration should be 1-4 hours only")]
        public int? Duration { get; set; }

        [Display(Name = "Organiser")]
        [Required(ErrorMessage = "Please Enter your Name")]
        public string Organiser { get; set; }

        [Display(Name = "Type of Event")]
        public string EventType { get; set; }

        [Display(Name = "Invited People")]
        public string Invitees { get; set; }

        [ForeignKey("EventId")]
        public ICollection<Comment> Comments { get; set; }
    }
}
