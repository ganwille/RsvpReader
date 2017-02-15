using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSVPWebApi.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Web;

    using RSVPWebApi.Data;
    using RSVPWebApi.Logic;
    using RSVPWebApi.Models;

    public class BooksController : ApiController
    {

        public IEnumerable<string> GetAllBooks()
        {
            var text = RsvpEngine.CutText(BooksData.books.FirstOrDefault());
            return text;
        }

        public IHttpActionResult GetBook(int id)
        {
            var book = BooksData.books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return this.NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        [ActionName("UploadFile")]
        public async Task<HttpResponseMessage> UploadPdf()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                string fileName = string.Empty;
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                    fileName = file.LocalFileName;
                }

                var pdfContent = PdfLogic.ReadPdfFile(fileName);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

    }
}
