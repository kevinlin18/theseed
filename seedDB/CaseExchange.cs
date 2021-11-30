namespace seedDB {
    [Dapper.Contrib.Extensions.Table("CaseExchange")]
    public class CaseExchange {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string type { get; set; }
        public string receipt { get; set; }
        public string result { get; set; }
        public string filePath { get; set; }
    }
}
