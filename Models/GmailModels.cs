using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CandleShop.Models
{
    public class gmail
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}