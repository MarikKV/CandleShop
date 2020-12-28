using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CandleShop.Models
{
    public class Candle
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("image")]
        public string CandleImage { get; set; }

        [BsonElement("name")]
        public string CandleName { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("describe")]
        public string Describe { get; set; }

        [BsonElement("amont")]
        public int Amount { get; set; }
    }
}