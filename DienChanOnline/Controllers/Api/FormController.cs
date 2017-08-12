using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DienChanOnline.Models;
using Language = DienChanOnline.Models.Structs.Language;

namespace DienChanOnline.Controllers.Api
{
    public class FormController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FormController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/form/lan/1
        public IHttpActionResult GetFormTitle(string lang = "en", int id = 0)
        {
            var form = new Form
            {
                Title = "Customer Information",
                TitleVn = "Thông Tin Khách Hàng",
                TitleFr = "Informations Importants"
            };

            if (id != 0)
                form = _context.Forms.SingleOrDefault(f => f.Id == id);

            if (form == null)
                return BadRequest("Form doesn't exist!!!");

            switch (lang)
            {
                case Language.Vietnamese:
                    return Ok(form.TitleVn);
                case Language.French:
                    return Ok(form.TitleFr);
                default:
                    return Ok(form.Title);

            }
        }
    }
}
