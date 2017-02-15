using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVPWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}