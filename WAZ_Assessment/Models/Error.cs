using System;
using System.Collections.Generic;
using System.Text;

namespace WAZ_Assessment.Models
{
    public class Error
    {
        public string message { get; set; }
        public string stackTrace { get; set; }
        public string innerException { get; set; }
        public string columnName { get; set; }
        public string columnValue { get; set; }
    }
}
