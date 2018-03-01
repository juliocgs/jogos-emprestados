using System.Collections.Generic;

namespace MVC.Models
{
    public class DataTableRequest
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public Dictionary<string, string> search { get; set; }
        public List<Dictionary<string, string>> order { get; set; }
        public List<Dictionary<string, string>> columns { get; set; }
    }

    public enum DataTableColumnOrderDirection
    {
        asc, desc
    }

    public class DatatableColumnOrder
    {
        public int column { get; set; }
        public DataTableColumnOrderDirection dir { get; set; }
    }
    public class DataTableColumnSearch
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class DataTableColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DataTableColumnSearch search { get; set; }
    }
}