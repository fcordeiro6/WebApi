using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI1.Models
{
    public class Contato
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string canal { get; set; }
        public string valor { get; set; }
        public string obs { get; set; }
    }
}