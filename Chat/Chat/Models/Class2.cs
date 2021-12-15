using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Chat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Mat { get; set; }   
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public DateTime Date { get; set; }
    }
}