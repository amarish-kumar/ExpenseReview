
using System;
using System.IO;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReimbursementApp.Data.Contracts;
using ReimbursementApp.Model;

namespace ReimbursementApp.Controllers.API
{
    [Route("/api/expense/{Id}/files")]
    public class DocumentController :Controller
    {
        private IHostingEnvironment _host;
        private IExpenseReviewUOW _uow;
        private DocumentSettings _options;

        public DocumentController(IHostingEnvironment host, IExpenseReviewUOW uow, IOptionsSnapshot<DocumentSettings> options)
        {
            _host = host;
            _uow = uow;
            _options = options.Value;
        }

        [HttpPost]
        public IActionResult Upload(int Id, IFormFile file)
        {
            var expense = _uow.Expenses.GetById(Id);
            if (expense == null)
            {
                return NotFound();
            }

            if (file == null) return BadRequest("File not valid");
            if (file.Length == 0) return BadRequest("Empty File");
            if (file.Length > _options.MaxBytes) return BadRequest("File exceeded 10 MB size!");

            if (!_options.IsSupported(file.FileName)) return BadRequest("Invalid File Type");
            var uploadsFolder = Path.Combine(_host.WebRootPath, "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filepath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var image = new Documents {DocName = fileName};
            //TODO: Expense is going to have the relationship with Documents as well, hence virtual key is required
         //   expense.Images.Add(image);
            _uow.Commit();
            return Ok(image);
        }
    }

   
}
