using Rubel_Rana_1249804.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;

namespace Rubel_Rana_1249804.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly StudentDbContext db = new StudentDbContext();
        // GET: Reports
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult StudentCourse()
        {
            var data = db.StudentCourses
               .GroupBy(x => x.Cours.CourseName)
               .Select(x => new StudentCourseRpt
               {
                   Course = x.Key,
                   Students = x.Select(p => p.Student)
               });
            return View(data.ToList());
        }
        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml, string reportName = "")
        {
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                string fileName = (reportName == "" ? "Report" : reportName) + DateTime.Now.Ticks + ".pdf";
                return File(stream.ToArray(), "application/pdf", fileName);
            }
        }
    }
}