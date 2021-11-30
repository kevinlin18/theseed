using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace theseed.Controllers {
    public class SearchController : Controller {
        public IActionResult Get([FromBody]SearchModel model) {
            var results = new List<SearchResult>();
            var sql = "SELECT type,receipt,result FROM CaseExchange WHERE phone=@phone";
            using (var conn = new SqlConnection(Define.ConnStr)) {
                results = conn.Query<SearchResult>(sql, model).AsList();
            }
            return Json(results);
        }
        public class SearchModel {
            public string phone { get; set; }
        }
        public class SearchResult {
            public string type { get; set; }
            public string receipt { get; set; }
            public string result { get; set; }
        }
    }
}
