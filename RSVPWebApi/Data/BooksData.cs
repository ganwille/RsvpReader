using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVPWebApi.Data
{
    using RSVPWebApi.Models;

    public class BooksData
    {
        public static Book[] books = new Book[]
                           {
                                       new Book { Id = 1, Title = "Lorem Ipsum", Text = "Lorem ipsum ipsum lorem" },
                                       new Book
                                           {
                                               Id = 2,
                                               Title = "Ipsum Lorem",
                                               Text = "ipsum lorem Lorem ipsum ipsum lorem"
                                           },
                           };
    }
}