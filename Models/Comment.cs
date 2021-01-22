
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPopper.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        public string CommentBy { get; set; }

        public string CommentText { get; set; }

        public DateTime? CommentDateTime { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
            