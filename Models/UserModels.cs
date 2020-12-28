using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CandleShop.Models
{
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }
    }
}