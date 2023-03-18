using System;

namespace Rooydaad.Web.Models
{
    public class Event
    {
        public  DateTime CreatedAt { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
    }
    public class EventViewModel
    {
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
    }
}
