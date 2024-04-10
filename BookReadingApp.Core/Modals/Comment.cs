using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingApp.Core.Modals
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "Please write the comment before posting")]
        public string comment { get; set; }
        public DateTime TimeStamp { get; set; }

        public Event _Event { get; set; }

        public Comment()
        {
            TimeStamp = DateTime.Now;
        }
    }

}
