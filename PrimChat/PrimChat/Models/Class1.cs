using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrimChat.Models
{

    public class User
    {
        public int id { get; set; }
        public string mat { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Message
    {
        public int MessageId { get; set; }
        public string mat { get; set; }
        public int id_first { get; set; }
        public int id_second { get; set; }
    }
}