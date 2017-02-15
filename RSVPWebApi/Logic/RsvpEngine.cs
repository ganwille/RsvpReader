using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVPWebApi.Logic
{
    using RSVPWebApi.Models;

    public static class RsvpEngine
    {
        public static List<string> CutText(Book book)
        {
            var wordsList = book.Text.Split(' ').ToList();
            return wordsList;
        }
    }
}