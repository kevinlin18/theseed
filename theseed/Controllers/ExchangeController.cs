using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using theseed.Models;

namespace theseed.Controllers {
    public class ExchangeController : Controller {
        public IActionResult Create(CreateModel model) {
            var result = new BasicResult();
            try {
                var path = @"C:/temp/img.jpg";
                if (model.fileReceipt != null) {
                    using (var stream = new FileStream(path, FileMode.Create)) {
                        model.fileReceipt.CopyTo(stream);
                    }
                }
                using (var conn = new SqlConnection(Define.ConnStr)) {
                    var caseExchange = new seedDB.CaseExchange {
                        name = model.name,
                        phone = model.phone,
                        address = model.address,
                        receipt = model.receipt,
                        type = model.type,
                        result = "審核中",
                        filePath = path,
                    };
                    conn.Insert(caseExchange);
                }

                result.success = true;
            } catch (Exception ex) {
                result.message = ex.ToString();
            }

            return Json(result);
        }
        public class CreateModel {
            public string name { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
            public string type { get; set; }
            public string receipt { get; set; }
            public IFormFile fileReceipt { get; set; }
        }
    }
}
