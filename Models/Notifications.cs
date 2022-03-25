using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.ModelsModels
{
    public class Notifications
    {
        public string id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string recipient { get; set; }
        public bool readStatus { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateRead { get; set; }
    } 
    public class Notifica
    {
        public string id { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string recipient { get; set; }
        public bool readStatus { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateRead { get; set; }
    }
}
