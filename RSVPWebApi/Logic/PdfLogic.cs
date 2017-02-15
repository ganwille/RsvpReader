using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSVPWebApi.Logic
{
    using System.IO;
    using System.Text;

    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;

    public static class PdfLogic
    {
        public static string ReadPdfFile(string fileName)
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(fileName))
            {
                PdfReader pdfReader = new PdfReader(fileName);

                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText  = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.UTF8.GetBytes(currentText)));
                    text.Append(currentText);
                    pdfReader.Close();
                }
            }
            return text.ToString();
        }


    }
}